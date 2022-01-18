<template>
    <div>
        <button @click="redirect">跳转</button>
    </div>
</template>

<script>
export default {
    methods: {
        redirect(){
            this.$router.push({ path: '/view', query: { id: 1 }})
        }
    },
}
</script>