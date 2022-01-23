<template>
    <div class="order">
        <div>
            <img src="../assets/top.jpg" width="1262" style="width: 1262px" />
        </div>
        <div class="step">
            <el-steps :active="1">
                <el-step title="我的购物车" icon="el-icon-edit"></el-step>
                <el-step title="确认订单信息" icon="el-icon-upload"></el-step>
                <el-step title="提交订单" icon="el-icon-picture"></el-step>
            </el-steps>
        </div>
        <el-descriptions title="基本信息" :column="3" border class="desc">
            <el-descriptions-item
                label="用户名"
                label-class-name="my-label"
                content-class-name="my-content"
            >
                {{ user.userName }}
            </el-descriptions-item>
            <el-descriptions-item label="手机号">
                {{ user.phone }}
            </el-descriptions-item>
            <el-descriptions-item label="居住地">
                {{ user.province }}
            </el-descriptions-item>
            <el-descriptions-item label="邮箱">
                <el-tag size="small">
                    {{ user.email }}
                </el-tag>
            </el-descriptions-item>
            <el-descriptions-item
                label="联系地址"
                :contentStyle="{ 'text-align': 'left', color: 'red' }"
            >
                {{ user.address }}
            </el-descriptions-item>
        </el-descriptions>

        <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span>收货地址选择</span>
                <el-button
                    style="float: right; padding: 3px 0"
                    type="text"
                    @click="AddAddress"
                    >添加</el-button
                >
            </div>

            <ul>
                <li v-for="item in ShipAddress" :key="item.addressId">
                    <el-radio v-model="addressId" :label="item.addressId">
                        {{ item.address }}
                    </el-radio>
                </li>
            </ul>
        </el-card>

        <el-dialog title="收货地址" :visible.sync="dialogTableVisible">
            <ship-address></ship-address>
        </el-dialog>
        <div>
            <img src="../assets/ship.jpg" width="1262" style="width: 1262px" />
        </div>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column prop="cartId" label="选择" width="180">
            </el-table-column>
            <el-table-column label="商品">
                <template slot-scope="scope">
                    <div style="float: left">
                        <img :src="format(scope.row.goodsImg)" width="60" />
                    </div>
                    <div style="float: left; margin-left: 20px">
                        {{ scope.row.goodsName }}
                    </div>
                </template>
            </el-table-column>
            <el-table-column prop="price" label="单价"> </el-table-column>
            <el-table-column prop="price" label="数量">
                <template slot-scope="scope">
                    {{ scope.row.buyCount }}
                </template>
            </el-table-column>
            <el-table-column label="小计">
                <template slot-scope="scope">
                    {{ scope.row.price * scope.row.buyCount }}
                </template>
            </el-table-column>
            <el-table-column prop="price" label="删除">
                <template slot-scope="scope">
                    <el-button type="success" @click="del(scope)"
                        >删除</el-button
                    >
                </template>
            </el-table-column>
        </el-table>
        <div class="priceInfo clearfix">
            <div class="floatleft">
                给卖家留言：
                <el-input
                    type="textarea"
                    :rows="2"
                    placeholder="请输入内容"
                    v-model="remark"
                >
                </el-input>
            </div>
            <div class="floatright">应付金额：<span>¥{{total}}</span>元</div>
        </div>
        <div class="floatright">
             <el-button type="danger" @click="createOrder">提交订单</el-button>
        </div>
    </div>
</template>

<style>
ul li {
    list-style: none;
    margin: 0;
    padding: 0;
    height: 40px;
}
.order,
.priceInfo {
    width: 1262px;
    margin: 0 auto;
}
.step,
.desc,
.box-card {
    margin-top: 3em;
}

.my-label {
    background: #e1f3d8;
}

.my-content {
    background: #fde2e2;
}
.priceInfo {
    background: #efeeee;
}
.priceInfo .floatleft {
    float: left;
    width: 25%;
    margin: 16px;
}
.el-textarea {
    margin-top: 12px;
}
.priceInfo .floatright,
.floatright {
    float: right;
    margin: 16px 30px 40px 60px;
    font-size: 2em;
}
/*.   #   空格   html元素   >*/
.priceInfo .floatright span {
    color: red;
}
.clear {
    height: 0;
    clear: both;
}
.clearfix:after {
    content: ".";
    display: block;
    height: 0;
    clear: both;
    visibility: hidden;
}
.clearfix {
    display: inline-block;
}
/* Hides from IE-mac */
*html .clearfix {
    height: 1%;
}
.clearfix {
    display: block;
}
/* End hide from IE-mac */
</style>


<script>
import ShipAddress from "./shipAddress.vue";

export default {
    components: {
        ShipAddress,
    },
    data() {
        return {
            user: {
                userId: 0,
                userName: "",
                phone: "",
                province: "",
                email: "",
                address: "",
            },
            remark: "",
            dialogTableVisible: false,
            addressId: 0,
            ShipAddress: [],
            tableData: [],
        };
    },
    computed:{
        total:function(){
            let _total = 0;

            this.tableData.forEach(v=>{
                _total += v.buyCount * v.price;
            });

            return _total;
        }
    },
    methods: {
        AddAddress() {
            this.dialogTableVisible = true;
        },
        format(path) {
            return "http://localhost:5000" + path;
        },
        del(scope) {
            this.axios
                .get(`/api/Cart/Delete?CartId=${scope.row.cartId}`)
                .then((m) => {
                    this.getcart();
                });
        },
        getcart() {
            this.axios.get("/api/Cart/GetCart").then((m) => {
                this.tableData = m.data;
            });
        },
        createOrder(){
            this.axios.get(`/api/order/create?AddressId=${this.addressId}&Remark=${this.remark}`).then(m=>{
                //
                if(m.data.code == 0){
                    //弹出消息
                    //跳转到支付页面
                }
            });
        }
    },
    mounted() {
        this.axios.get("/api/user/GetLoginInfo").then((m) => {
            this.user = m.data;
        });

        //获取收货地址
        this.axios.get("/api/user/GetAddress").then((m) => {
            this.ShipAddress = m.data;
        });

        this.getcart();
    },
};
</script>