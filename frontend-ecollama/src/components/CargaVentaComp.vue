<template>
  <div class="container">
    <div class="text-center mt-5">
      <h1>Cargar Venta</h1>
    </div>
    <br>
    <modal-product-selec :visible="dialog" @dialog="dialog=$event" @idselected="idselected=$event"></modal-product-selec>
    <vue-basic-alert :duration="300" ref="alert" />
    <div class="row">
      <div class="col-lg-7 mx-auto">
        <div class="card mt-2 mx-auto p-4 bg-dark">
          <div class="card-body bg-light">
            <div class="container">
              <form id="contact-form" role="form" @submit="sendForm">
                <div class="controls">
                  <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_producto">Cliente *</label>
                        <select
                          id="form_cliente"
                          name="cliente"
                          v-model="venta.idCliente"
                          class="form-control"
                          required="required"
                          data-error="Seleccione un cliente."
                        >
                          <option
                            v-for="c in clientes"
                            :key="c.id"
                            :value="c.id"
                          >
                            {{ c.nombre }}
                          </option>
                        </select>
                      </div>
                    </div>

                  </div>

                  <div class="row"> 
                    
                    <!-- <div class="col-md-6">  -->
                      <!-- <div class="form-inline"> -->
                        <div class="d-flex align-items-center">
                          <label class="me-3" for="form_producto">Producto*</label>
                          <!--<select
                            id="form_producto"
                            name="producto"
                            v-model="venta.idProducto"
                            class="form-control"
                            required="required"
                            data-error="Seleccione un producto."
                          >
                            <option
                              v-for="p in producto"
                              :key="p.idProducto"
                              :value="p.idProducto"
                            >
                              {{ p.descripcion }}
                            </option>
                          </select>-->
                          <input
                            class="form-control me-2"
                            id="form_producto"
                            type="button"
                            name="producto"
                            v-model="venta.idProducto"
                            
                            placeholder=""
                            required="required"
                            data-error=""
                            
                            
                          />
                          <input
                          
                          @click="MostrarDialog()"
                          type="button"
                          class="btn btn-outline-dark"
                          id="form-btn-product"
                          value="..."
                          />
                        
                          
                         
                        </div> 
                      <!-- </div> -->
                      
                      <!-- </div> -->
                    
                    
                    
                  </div> 

                  <div class="row">
                    <div class="col-md-4">
                      <div class="form-group">
                        <label for="form_pallets">Pallets *</label>
                        <input
                          id="form_pallets"
                          type="number"
                          name="pallets"
                          v-model="venta.cantpallet"
                          class="form-control"
                          placeholder="Ingrese la cantidad de pallet *"
                          required="required"
                          data-error="La cantidad de pallet es requerida."
                        />
                      </div>
                    </div>
                    <div class="col-md-4">
                      <div class="form-group">
                        <label for="form_bolsas">Bolsas *</label>
                        <input
                          id="form_bolsas"
                          v-model="cantidadbolsas"
                          type="number"
                          class="form-control"
                          placeholder="Ingrese la cantidad de bolsas*"
                          required="required"
                          data-error="La cantidad de bolsas es requerida."
                        />
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_preciounitario"
                          >Precio Unitario *</label
                        >
                        <input
                          id="form_preciounitario"
                          v-model="preciounitario"
                          type="number"
                          step="0.1"
                          name="preciounitario"
                          class="form-control"
                          text="Ingrese el precio unitario*"
                          required="required"
                          data-error="El precio unitario es requerido."
                          
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_preciototal">Precio Total</label>
                        <input
                          id="form_preciototal"
                          type="number"
                          step="0.1"
                          v-model="totalventa"
                          class="form-control"
                        />
                      </div>
                    </div>
                  </div>

                  <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_fecha">Fecha*</label>
                        <input
                          id="form_fecha"
                          type="date"
                          name="fecha"
                          v-model="venta.fecha"
                          class="form-control"
                          placeholder="Ingrese la fecha *"
                          required="required"
                          data-error="La fecha es requerida."
                        />
                      </div>
                    </div>
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_formapago"
                          >Ingrese la forma de pago *</label
                        >
                        <select
                          id="form_formapago"
                          name="formapago"
                          v-model="venta.formadepago"
                          class="form-control"
                          required="required"
                          data-error="Please specify your need."
                        >
                          <option value="" selected disabled>
                            --Seleccione una opcion--
                          </option>
                          <option>Efectivo</option>
                          <option>Transferencia</option>
                        </select>
                      </div>
                    </div>
                  </div>
                  <div class="row">
                    <div class="col-md-6">
                      <div class="form-group">
                        <label for="form_Transporte">Transporte</label>
                        <input
                          id="form_Transporte"
                          type="text"
                          v-model="venta.transporte"
                          class="form-control"
                          placeholder="Ingresa trasnporte *"
                          required="required"
                          data-error="El transporte es requerido."
                        />
                      </div>
                    </div>
                    
                  </div>

                  <div class="form-group">
                    <div class="form-check">
                      <input
                        class="form-check-input"
                        type="checkbox"
                        v-model="venta.despachado"
                        value=""
                        id="invalidCheck"
                      />
                      <label class="form-check-label" for="invalidCheck">
                        Despachado
                      </label>
                      <div class="invalid-feedback"></div>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="form-check">
                      <input
                        class="form-check-input"
                        type="checkbox"
                        v-model="venta.abonado"
                        value=""
                        id="invalidCheck"
                      />
                      <label class="form-check-label" for="invalidCheck">
                        Abonado
                      </label>
                      <div class="invalid-feedback"></div>
                    </div>
                  </div>
                  <br />
                  <div class="row">
                    <div class="col-md-12">
                      <input
                        type="submit"
                        class="btn btn-warning btn-send pt-2 btn-block"
                        value="CARGAR"
                      />
                    </div>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
      <!-- /.8 -->
    </div>
    <!-- /.row-->
  </div>
  <br />
  
</template>

<script>
//var total = 0;
//var idVenta
import VueBasicAlert from "vue-basic-alert";
import ModalProductSelec from "./ModalProductSelec.vue";
//import {ref} from 'vue';
export default {
  name: "CargaVentaComp",
  components: {
    VueBasicAlert,
    ModalProductSelec,
  },
  

  data() {
    return {
      dialog: false,
      idselected: 0,
      preciounitario: 0,
      totalventa: 0,
      cantidadbolsas: 0,
      idVenta: "",
      venta: {
        idCliente: "",
        idProducto: "",
        cantbolsas: this.cantidadbolsas,
        cantpallet: "",
        preciounitario: this.preciounitario,
        preciototal: this.totalventa,
        fecha: "",
        formadepago: "",
        transporte: "",
        abonado: "",
        despachado: "",
      },
      producto: [],
      clientes: [],
    };
  },

  methods: {
    sendForm(e) {
      e.preventDefault(); // esto hace que no se actualice el formulario y se puedan captar los datos
      //console.log(this.venta)

      this.insert();
    },
    insert() {
      fetch("https://localhost:44329/api/Venta", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          idProducto: this.venta.idProducto,
          idCliente: this.venta.idCliente,
          pallets: this.venta.cantpallet,
          bolsas: this.venta.cantbolsas,
          precioUnitario: this.venta.preciounitario,
          precioTotal: this.venta.preciototal,
          fecha: this.venta.fecha,
          formaPago: this.venta.formadepago,
          transporte: this.venta.transporte,
          abonado: true,
          despachado: true,
        }),
      })
        .then((response) => {
          if (response.ok) return response.json();
        })
        .then((data) => {
          console.log(data),
            (this.idVenta = data.id),
            this.ShowModalAlert(this.idVenta);
        })
        .catch((err) => console.log(err));
    },
    CalTotalProd: function () {
     /*  var precuni = document.getElementById("form_preciounitario").value;
      var cantbolsas = document.getElementById("form_bolsas").value;
      total = precuni * cantbolsas;
      document.getElementById("form_preciototal").value = total;
      document.getElementById("form_preciototal").placeholder = total;
      this.venta.preciototal = total;
      // document.getElementById("form_preciototal").disabled = true;

      //console.log('totalventa:' + this.totalventa)
      console.log("totalventa:" + total); */
    },
    MostrarDialog: function (){
      this.dialog = !this.dialog
    },
    ShowModalAlert(id) {
      this.$refs.alert.showAlert(
        "success",
        "Id de Venta: " + id,
        "Se cargo correctamente"
      );
    },
  },

  mounted() {
   /*  fetch("https://localhost:44329/api/Productos")
      .then((res) => res.json())
      .then((res) => (this.producto = res)); */

    fetch("https://localhost:44329/api/Clientes")
      .then((res) => res.json())
      .then((res) => (this.clientes = res));
  },
  updated() {
    
    
    if (this.idselected != 0){
      //console.log('se selecciono datos' + this.idselected.idProducto)
      document.getElementById("form_preciounitario").value = this.idselected.precioDistribuidor
      document.getElementById("form_preciounitario").placeholder = this.idselected.precioDistribuidor
      document.getElementById("form_producto").value = this.idselected.descripcion
    }
    //this.CalTotalProd();
  },
  
  watch: {
    cantidadbolsas: function(){
      
      this.totalventa = this.preciounitario * this.cantidadbolsas
      var precuni = document.getElementById("form_preciounitario").value;
      var cantbolsas = document.getElementById("form_bolsas").value;
      this.totalventa = precuni * cantbolsas;
      //console.log('entro watch cantidad bolsas ' + this.totalventa)
    }
  }
};
</script>

<style lang="scss" scoped>
</style>                             