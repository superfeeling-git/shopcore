<template>
    <div>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column prop="price" label="选择" width="180">
            </el-table-column>
            <el-table-column  label="商品">
                <template slot-scope="scope">
                    <div style="float:left;">
                        <img :src="format(scope.row.goodsImg)" width="60">
                    </div>
                    <div style="float:left;margin-left:20px;">
                    {{scope.row.goodsName}}
                    </div>
                </template>
            </el-table-column>
            <el-table-column prop="price" label="单价"> </el-table-column>
            <el-table-column prop="price" label="数量">
                <template slot-scope="scope">
                    <el-input-number size="mini" @change="handleChange" v-model="scope.row.buyCount"></el-input-number>
                </template>
            </el-table-column>
            <el-table-column label="小计">
                <template slot-scope="scope">
                    {{scope.row.price * scope.row.buyCount}}
                </template>
            </el-table-column>
        </el-table>
        <div>
            合计：{{total}}
        </div>
    </div>
</template>

<script>
export default {
    data() {
        return {
            tableData:[]
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
        format(path){
            return "http://localhost:5000"+ path;            
        },
        handleChange(v,h){
            console.log(this);
        }
    },
    mounted() {
        this.axios.get("/api/Cart/GetCart").then((m) => {
            this.tableData = m.data;
        });
    },
};
</script>