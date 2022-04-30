<template>
    <div v-if="!isDettaglio">
        <h1 class="display-6">{{title}}</h1>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>
                        Citt&#224;
                    </th>
                    <th>
                        Indirizzo
                    </th>
                    <th>
                        Cap
                    </th>
                    <th>
                        Provincia
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(item, i) in items" :key="i">
                    <td>
                        {{item.citta}}
                    </td>
                    <td>
                        {{item.indirizzo}}
                    </td>
                    <td>
                        {{item.cap}}
                    </td>
                    <td>
                        {{item.provincia}}
                    </td>
                </tr>
            </tbody>
            <tfoot>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td style="text-align: right;">
                        <router-link to="/citta/dettaglio" class="btn btn-primary"><i class="fas fa-plus"></i> Nuova Citta</router-link>
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
    import { useRouter } from 'vue-router'

    export default {
        name: 'ElencoCitta',
        data() {
            return {
                title: 'Citta',
                items: [
                    { citta: 'Milano', indirizzo: 'via Bovisasca 10', cap: '20001', provincia: 'MI' },
                    { citta: 'Monza', indirizzo: 'via Roma 34', cap: '20002', provincia: 'MB' },
                    { citta: 'Lodi', indirizzo: 'via Garibaldi 3', cap: '20003', provincia: 'LO' }
                ]
            };
        },
        computed: {
            isDettaglio() {
                return useRouter().currentRoute.value.fullPath.indexOf('dettaglio') > -1;
            }
        }
    }
</script>
