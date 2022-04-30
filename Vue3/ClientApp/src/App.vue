<template>
    <v-app>
        <nav class="navbar navbar-expand-lg navbar-light bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand text-white" href="#">Vue3</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <!--<ul class="navbar-nav me-auto offset-md-5 mb-2 mb-lg-0">
                        <li class="nav-item">
                            <h3 class="text-white">Gestione Progetti</h3>
                        </li>
                    </ul>-->
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

        <!--<nav class="navbar navbar-light bg-primary">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">Confluence</a>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link active" aria-current="page" href="#">Gestione Progetti</a>
                        </li>
                    </ul>
                    <form class="d-flex">
                        <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search">
                        <button class="btn btn-outline-success" type="submit">Search</button>
                    </form>
                </div>
            </div>
        </nav>-->

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



        <!--<v-navigation-drawer persistent
                             :mini-variant="miniVariant"
                             :clipped="clipped"
                             v-model="drawer"
                             enable-resize-watcher
                             fixed
                             app>
            <v-list>
                <v-list-item value="true" v-for="(item, i) in items" :key="i" :to="item.link">
                    <v-list-item-action>
                        <v-icon v-html="item.icon"></v-icon>
                    </v-list-item-action>
                    <v-list-item-content>
                        <v-list-item-title v-text="item.title"></v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>
        </v-navigation-drawer>

        <v-app-bar app :clipped-left="clipped" color="info" dark>
            <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
            <v-btn class="d-none d-lg-flex" icon @click.stop="miniVariant = !miniVariant">
                <v-icon v-html="miniVariant ? 'mdi-chevron-right' : 'mdi-chevron-left'"></v-icon>
            </v-btn>
            <v-btn class="d-none d-lg-flex" icon @click.stop="clipped = !clipped">
                <v-icon>mdi-web</v-icon>
            </v-btn>
            <v-toolbar-title v-text="title"></v-toolbar-title>
            <v-spacer></v-spacer>
        </v-app-bar>

        <v-main>
            <router-view />
        </v-main>

        <v-footer app>
            <span v-text="title"></span>
        </v-footer>-->
    </v-app>
</template>

<script>
    export default {
        data() {
            return {
                title: 'Confluence'
            };
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

