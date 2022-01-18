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
                <el-button style="float: right; padding: 3px 0" type="text" @click="AddAddress"
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
    </div>
</template>

<style>
ul li {
    list-style: none;
    margin: 0;
    padding: 0;
    height: 40px;
}
.order {
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
</style>


<script>
import ShipAddress from './shipAddress.vue'

export default {
    components:{
        ShipAddress
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
            dialogTableVisible:false,
            addressId: 0,
            ShipAddress: [],
        };
    },
    methods: {
        AddAddress(){
            this.dialogTableVisible = true;
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
    },
};
</script>