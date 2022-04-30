<template>
    <v-app>
        <nav class="navbar navbar-expand-lg navbar-light bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand text-white" href="#">Vue3</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <div class="col-9"></div>
                    <div class="col-2" style="text-align: right;">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                    </div>
                    <div class="col-1" style="text-align: right;">
                        <a class="btn btn-light"><i class="fas fa-search"></i> Search</a>
                    </div>
                </div>
            </div>
        </nav>

        <div class="row" style="margin-top: 10px;">
            <div class="col-2">
                <ul class="nav nav-pills flex-column">
                    <li class="nav-item">
                        <router-link to="/citta" class="nav-link" active-class="bg-primary text-white"><i class="fa-solid fa-bars-progress"></i> Citta</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/ricerca" class="nav-link" active-class="bg-primary text-white"><i class="fa-solid fa-magnifying-glass"></i> Ricerche</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/utenti" class="nav-link" active-class="bg-primary text-white"><i class="fa-solid fa-users"></i> Utenti</router-link>
                    </li>
                </ul>
            </div>
            <div class="col">
                <router-view></router-view>
            </div>
        </div>
    </v-app>
</template>

<script>
    export default {
        data() {
            return {};
        }
    };
</script>
<style>
    .nav-link {
        padding: 0.8rem 2rem;
    }

    .nav-item:hover {
        background-color: lightgray;
    }
</style>

