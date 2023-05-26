<template>
  <v-app>
    <nav>
      
        <nav-comp></nav-comp>
    </nav>
    <v-main>
      <router-view></router-view>    
    </v-main>
    <footer>
      <FooterComp></FooterComp>
    </footer>
  </v-app>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import FooterComp from './components/FooterComp.vue'
//import HomeComp from './components/HomeComp.vue';
import NavComp from './components/NavComp.vue';
export default {
  name: 'App',

  components: {
    //HelloWorld,
    FooterComp,
    //HomeComp,
    NavComp
  },

  data: () => ({
    //
  }),
}
</script>
