<template>
    <v-input messages="hola" v-model="search" prepend-icon="search">
    </v-input>
</template>
<script>
export default {
    computed: {
        search: {
            get(){
                return this.$store.state.query;
            },
            set(val){
                this.$store.commit(SET_QUERY,val);
            }
        }
    }
}
</script>

