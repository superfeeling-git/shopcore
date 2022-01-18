<template>
    <div>
        <el-form
            :model="ruleForm"
            ref="ruleForm"
            label-width="100px"
            class="demo-ruleForm"
        >
            <el-form-item label="收货人姓名" prop="fullName">
                <el-input v-model="ruleForm.fullName"></el-input>
            </el-form-item>
            <el-form-item label="电话" prop="tEL">
                <el-input v-model="ruleForm.tEL"></el-input>
            </el-form-item>
            <el-form-item label="邮箱" prop="email">
                <el-input v-model="ruleForm.email"></el-input>
            </el-form-item>
            <el-form-item label="省市县" prop="region">
                <el-cascader
                    v-model="value"
                    :options="areas"
                    @change="handleChange"
                ></el-cascader>
            </el-form-item>
            <el-form-item label="地址" prop="email">
                <el-input v-model="ruleForm.address"></el-input>
            </el-form-item>
            <el-form-item label="是否默认" prop="isDefault">
                <el-switch v-model="ruleForm.isDefault"></el-switch>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')"
                    >保存收货地址</el-button
                >
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
import areas from './areas'

export default {
    data() {
        return {
            ruleForm: {
                addressId: 0,
                fullName: "",
                province: "",
                city: "",
                area: "",
                email: "",
                address: "",
                tEL: "",
                isDefault: false,
                
            },
            value: [],
            areas:[]            
        };
    },
    methods: {
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.axios.post('/api/user/Create',this.ruleForm).then(m=>{
                        console.log(m);
                    });
                } else {
                    console.log("error submit!!");
                    return false;
                }
            });
        },
        handleChange(value) {
            this.ruleForm.province = value[0];
            this.ruleForm.city = value[1];
            this.ruleForm.area = value[2];
        },
        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
    },
    mounted() {
        this.areas = areas;
    },
};
</script>