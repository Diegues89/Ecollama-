<template>
  <div class="container">
    <div class="text-center mt-5">
      <h1>Listado de ventas</h1>
    </div>
    <div v-if="ventas != null">
      <table class="table table-striped table-dark">
        <thead>
          <tr>
            <th scope="col">id</th>
            <th scope="col">Cliente</th>
            <th scope="col">Producto</th>
            <th scope="col">Pallets</th>
            <th scope="col">Bolsas</th>
            <th scope="col">PrecioUnitario</th>
            <th scope="col">PrecioTotal</th>
            <th scope="col">Fecha</th>
            <th scope="col">FormaPago</th>
            <th scope="col">Transporte</th>
            <th scope="col">Despachado</th>
            <th scope="col">Abonado</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="v in paginated" :key="v.id">
            <td>{{ v.id }}</td>
            <td>{{ v.cliente }}</td>
            <td>{{ v.producto }}</td>
            <td>{{ v.pallets }}</td>
            <td>{{ v.bolsas }}</td>
            <td>{{ v.precioUnitario }}</td>
            <td>{{ v.precioTotal }}</td>
            <td>{{ v.fecha }}</td>
            <td>{{ v.formaPago }}</td>
            <td>{{ v.transporte }}</td>
            <td>{{ v.despachado }}</td>
            <td>{{ v.abonado }}</td>
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
  </div>
</template>

<script>
export default {
  name: "VentaComp",
  data() {
    return {
      ventas: [],
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
  computed: {
    indexStart() {
      return this.current - 1 + this.pageSize;
    },
    indexEnd() {
      return this.indexStart + this.pageSize;
    },
    paginated() {
      return this.ventas.slice(this.indexStart, this.indexEnd);
    },
  },
  mounted() {
    fetch("https://localhost:44329/api/Ventas")
      .then((res) => res.json())
      .then((res) => (this.ventas = res))
      .then((json) => {
        this.totalregistros = json.length;
      });
  },
};
</script>

<style scoped>
</style>