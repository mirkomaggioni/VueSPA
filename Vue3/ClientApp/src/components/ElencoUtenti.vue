<template>
    <div v-if="!isDettaglio">
        <h1 class="display-6">{{title}}</h1>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>
                        Nome
                    </th>
                    <th>
                        Cognome
                    </th>
                    <th>
                        Nome utente
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(utente, i) in utenti" :key="i" v-on:click="apri(utente)">
                    <td>
                        {{utente.firstName}}
                    </td>
                    <td>
                        {{utente.lastName}}
                    </td>
                    <td>
                        {{utente.username}}
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td></td>
                    <td style="text-align: right;">
                        <router-link to="/utenti/dettaglio" class="btn btn-primary"><i class="fas fa-plus"></i> Nuovo Utente</router-link>
                    </td>
                </tr>

            </tfoot>
        </table>
    </div>
    <div v-if="isDettaglio">
        <router-view></router-view>
    </div>
</template>

<script>
    import { userService } from '../services/UserService'
    import { useRouter } from 'vue-router'

    export default {
        name: 'ElencoUtenti',
        data() {
            return {
                title: 'Utenti',
                utenti: []
            };
        },
        methods: {
            apri(utente) {
                this.$router.push({ path: '/utenti/dettaglio/' + utente.id });
            }
        },
        computed: {
            isDettaglio() {
                return useRouter().currentRoute.value.fullPath.indexOf('dettaglio') > -1;
            }
        },
        mounted() {
            userService.getAll().then(data => {
                this.utenti = data;
            })
        }
    }
</script>
