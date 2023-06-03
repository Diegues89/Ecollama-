<template>
  <div class="text-center" >
    <v-row justify="center">
    <v-dialog
      v-model="dialog"
      persistent
      width="1024"
    >
      
      <v-card>
        <v-card-title>
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            hide-details
          ></v-text-field>
        </v-card-title>
        <v-data-table
          v-model="selected"
          :headers="headers"
          :items="productos"
          single-select="singleSelect"
          item-key="descripcion"
          :search="search"
          show-select
        ></v-data-table>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="cerrar()"
          >
            Close
          </v-btn>
          
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
  </div>
</template>


<script>
//import { defineProps } from 'vue';
import { VDataTable } from 'vuetify/labs/VDataTable'

export default {

  name: 'ModalProductSelec',
  components: {
    VDataTable,
  },
  props: {
    title: {
      type: String
    },
    visible: {
      type: Boolean,
      //default: false,
    },
  },
  
  
  data() {
        return {
          dialog: this.visible,
          singleSelect: true,
          selecccion: 0,
          selected: [],
          search: '',
          productos: [],
          headers: [
          {
            title: 'Descripcion',
            align: 'start',
            sortable: false,
            key: 'descripcion',
          },
          { title: 'Id', key: 'idProducto' },
         
        ],
        desserts: [],
           
        }
    },
    
    updated() {
    //console.log(this.selected);
    
    //this.CalTotalProd();
    },
    watch: {
      visible: function(){
        this.dialog = this.visible
      },
      selected: function() {
        
        
        var selec 
        this.selected.forEach(function(id) {
          //this.$emit('idselected', id)
          
          selec = id,
          console.log(id)
          
        });
        //this.salir(idselec)
        this.selecccion = selec
        //this.$emit('idselected', idselec)
        //prueba comentario git
        }
      }, 
    mounted(){
      fetch("https://localhost:44329/api/Productos")
      .then((res) => res.json())
      .then((res) => (this.productos = res));
    },
    methods: {
        // salir: function(idselec){
        //   this.$emit('dialog', false)
        //   this.$emit('idselected', idselec)
        // },
        cerrar: function(){
          
          if (this.selected.length > 1)
            alert('Debe seleccionar solo una opcion')
          else 
            this.$emit('dialog', false) 
            this.$emit('idselected', this.selecccion)

        },
        
    }
}

</script>

<style>


</style>