<template>
    <div class="hello">
        <input type="text" v-model="UserDto.UserName" />
        <input type="text" v-model="UserDto.Password" />
        <button @click="outExe">登录</button>
    </div>
</template>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
    font-weight: normal;
}
ul {
    list-style-type: none;
    padding: 0;
}
li {
    display: inline-block;
    margin: 0 10px;
}
a {
    color: #42b983;
}
</style>
