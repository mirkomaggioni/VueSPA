<template>
    <h1 class="display-6">{{title}}</h1>
    <form id="userForm" class="row g-3">
        <div class="mb-12">
            <label for="firstName" class="form-label">Citta</label>
            <input type="text" class="form-control" id="firstName" v-model="progetto.citta">
        </div>
        <div class="mb-12">
            <label for="lastName" class="form-label">Indirizzo</label>
            <input type="text" class="form-control" id="fastName" v-model="progetto.indirizzo">
        </div>
        <div class="mb-12">
            <label for="username" class="form-label">Cap</label>
            <input type="text" class="form-control" id="username" v-model="progetto.cap">
        </div>
        <div class="mb-12">
            <label for="password" class="form-label">Provincia</label>
            <input type="password" class="form-control" id="password" v-model="progetto.provincia">
        </div>

        <div class="mb-12">
            <button type="button" class="btn btn-secondary" v-on:click="chiudi()" style="margin-left: 5px;"><i class="fas fa-close"></i> Chiudi</button>
        </div>
    </form>
</template>

<script>
    export default {
        name: 'DettaglioProgetti',
        data() {
            return {
                title: 'Progetto',
                progetto: {}
            };
        },
        methods: {
            chiudi() {
                this.$router.go(-1);
            }
        }
    }
</script>
