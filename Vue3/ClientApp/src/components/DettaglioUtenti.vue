<template>
    <h1 class="display-6">{{title}}</h1>
    <form id="userForm" class="row g-3">
        <div class="mb-12">
            <label for="firstName" class="form-label">Nome</label>
            <input type="text" class="form-control" id="firstName" v-model="user.firstName">
        </div>
        <div class="mb-12">
            <label for="lastName" class="form-label">Cognome</label>
            <input type="text" class="form-control" id="fastName" v-model="user.lastName">
        </div>
        <div class="mb-12">
            <label for="username" class="form-label">Username</label>
            <input type="text" class="form-control" id="username" v-model="user.username">
        </div>
        <div class="mb-12">
            <label for="password" class="form-label">Password</label>
            <input type="password" class="form-control" id="password" v-model="user.password">
        </div>

        <div class="mb-12">
            <button type="button" class="btn btn-primary" v-on:click="salva()"><i class="fas fa-save"></i> Salva</button>
            <button type="button" class="btn btn-secondary" v-on:click="chiudi()" style="margin-left: 5px;"><i class="fas fa-close"></i> Chiudi</button>
        </div>
    </form>
</template>

<script>
    import { userService } from '../services/UserService'

    export default {
        name: 'DettaglioUtenti',
        data() {
            return {
                title: 'Utente',
                user: {}
            };
        },
        methods: {
            salva() {
                if (this.user.firstName && this.user.lastName && this.user.username && this.user.password) {
                    userService.register(this.user).then(() => { this.$router.go(-1); });
                }
                
            },
            chiudi() {
                this.$router.go(-1);
            }
        },
        mounted() {
            var id = this.$route.params.id;
            if (id) {
                userService.getById(id).then(data => {
                    this.user = data;
                })
            }
        }
    }
</script>
