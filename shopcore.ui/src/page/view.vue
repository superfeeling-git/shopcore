<template>
    <div class="pageview">
        <div>
            <div class="rotateImg">
                <el-carousel :interval="5000" arrow="always">
                    <el-carousel-item v-for="item in goodsData.imgs" :key="item">
                        <img :src="item">
                    </el-carousel-item>
                </el-carousel>
            </div>
            <div class="BaseInfo">
                <h6>
                    {{goodsData.goodsName}}
                </h6>
                <div class="price">价格：<span>￥ {{goodsData.price}}</span></div>
                <div class="taste">
                    <el-radio v-model="skuid" v-for="item in taste" :key="item.skuid" :label="item.skuid" border
                        >
                        {{item.tasteName}}
                        </el-radio
                    >
                </div>
                <div class="addcar">
                    <el-input-number
                        v-model="num"
                        controls-position="right"
                        @change="handleChange"
                        :min="1"
                        :max="10"
                    ></el-input-number>
                    <el-button type="danger" @click="addcar">加入购物车</el-button>
                </div>
            </div>
        </div>
        <div class="Details">
            <h5>基本信息</h5>
            <div v-html="goodsData.details">
                
            </div>
        </div>
    </div>
</template>

<style>
.Details {
    clear: both;
    margin-top: 30px;
    padding-top: 40px;
}
.Details h5 {
    margin-top: 30px;
    font-size: 16px;
    text-align: left;
    margin: 0;
    line-height: 210%;
    border-bottom: 1px solid #c7c9cc;
    margin-bottom: 21px;
}
.BaseInfo {
    float: left;
    margin-left: 30px;
}
.BaseInfo div.price {
    text-align: left;
    font-size: 14px;
    margin: 16px;
    margin-left: 0;
}
.BaseInfo div.price span {
    color: #d61e10;
    font-size: 21px;
}
h6 {
    margin: 0;
    color: #d61e10;
    line-height: 40px;
    font-size: 20px;
    text-align: left;
}
div.taste {
    text-align: left;
    margin-top: 49px;
}
.addcar {
    text-align: left;
    margin-top: 41px;
}
.pageview {
    width: 80%;
    margin: 0 auto;
}
.rotateImg {
    float: left;
    width: 40%;
}
.el-carousel__item h3 {
    color: #475669;
    font-size: 18px;
    opacity: 0.75;
    line-height: 300px;
    margin: 0;
}

.el-carousel__item:nth-child(2n) {
    background-color: #99a9bf;
}

.el-carousel__item:nth-child(2n + 1) {
    background-color: #d3dce6;
}
</style>

<script>
export default {
    data() {
        return {
            taste:[],
            skuid:0,
            num: 1,
            goodsData:{
                goodsId:0,
                goodsName:'',
                price:0,
                imgs:[],
                details:''
            }
        };
    },
    methods: {
        handleChange(value) {
            console.log(value);
        },
        addcar(){
            this.axios.get('/api/user/islogin').then(m=>{
                if(m.data){                    
                    console.log(this.skuid)
                    console.log(this.num)
                    this.axios.post('/api/cart/addcart',
                    {
                        SKUID:this.skuid,
                        BuyCount:this.num
                    }).then(m=>{
                        console.log(m);
                    });
                }
            });

            
        }
    },
    mounted() {
        var id = this.$route.query.id;

        this.axios.get(`https://localhost:5001/api/Goods/GetEntity?id=${id}`).then(m=>{
            this.goodsData = m.data;
        });

        this.axios.get(`https://localhost:5001/api/Goods/GetTasteByGoods?id=${id}`).then(m=>{
            this.taste = m.data;
        });
    },
};
</script>