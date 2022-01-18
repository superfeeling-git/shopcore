<template>
    <div>
        <el-form
            :model="ruleForm"
            status-icon
            ref="ruleForm"
            label-width="100px"
            class="demo-ruleForm"
        >
            <el-form-item label="用户名" prop="UserName">
                <el-input
                    v-model="ruleForm.UserName"
                    autocomplete="off"
                ></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="Password">
                <el-input
                    type="password"
                    v-model="ruleForm.Password"
                    autocomplete="off"
                ></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')"
                    >提交</el-button
                >
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
//import axios from '../axios'
  export default {
    data() {     
      return {
        ruleForm: {
          UserName: '',
          Password: ''
        }
      };
    },
    methods: {
      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
              this.axios.post('/api/user/login',this.ruleForm).then(m=>{
                  console.log(m);
              });
          } else {
            console.log('error submit!!');
            return false;
          }
        });
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      }
    },
    mounted() {
        console.log(this.xxx);
    },
  }
</script>