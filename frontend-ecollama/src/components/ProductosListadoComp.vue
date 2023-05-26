<template>
  <div class="container">
    <div class="text-center mt-5">
      <h1>Listado de ventas</h1>
    </div>

    <table class="table table-striped table-dark">
      <thead>
        <tr>
          <th scope="col">id</th>
          <th scope="col">Descripcion</th>
          <th scope="col">PrecioDistribuidor</th>
          <th scope="col">PrecioMayorista</th>
          <th scope="col">PrecioConsumidorFinal</th>
          
        </tr>
      </thead>
      <tbody>
        <tr v-for="p in productos" :key="p.idProducto">
          <td>{{ p.idProducto }}</td>
          <td>{{ p.descripcion }}</td>
          <td>{{ p.precioDistribuidor }}</td>
          <td>{{ p.precioMayorista }}</td>
          <td>{{ p.precioConsumidorFinal }}</td>
          
        </tr>
      </tbody>
    </table>
    
  </div>
  <div class="text-center mt-5">
      
      
      <nav aria-label="Page navigation example" >
        <ul class="pagination justify-content-center">
          <li class="page-item"><a class="page-link text-dark" @click="prev()">Anterior</a></li>
          <li class="page-item"><a class="page-link text-dark" href="#">{{ current }}</a></li>
          <li class="page-item"><a class="page-link text-dark" @click="next()">Siguiente</a></li>
        </ul>
        <p>Total registros: {{ totalregistros }}</p>
      </nav>
      

      
    </div>
</template>

<script>
export default {
    name: "ProductosListadoComp",
    
  data() {
    return{
      
      productos:[],
      //Paginacion
      current: 1,
      pageSize: 10,
      totalregistros: 0,
    };
  },
  methods: {
    prev() {
      this.current--;
    },
    next() {
      this.current++;
    },
  },
  mounted() {
    fetch("https://localhost:44329/api/Productos")
      .then((res) => res.json())
      .then((res) => this.productos = res)
      .then((json) => {
        this.totalregistros = json.length;
      });

  },
  computed: {
    indexStart() {
      return this.current - 1 + this.pageSize;
    },
    indexEnd() {
      return this.indexStart + this.pageSize;
    },
    paginated() {
      return this.productos.slice(this.indexStart, this.indexEnd);
    },
  },
};
</script>

<style scoped>
</style>