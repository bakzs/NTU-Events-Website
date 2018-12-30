<template>
  <div>
    <b-container>
      <b-row>
        <b-col>
          <b-carousel id="carousel1"
                      controls
                      indicators
                      img-width="1024"
                      img-height="480"
          >
            <b-carousel-slide caption="Test Cca"
                              text="Test Text"
                              img-src="https://picsum.photos/1024/480/?image=52"
            ></b-carousel-slide>
          </b-carousel>
        </b-col>
      </b-row>
      <b-row>
        <b-col>
        <b-card-group deck>
          <b-card title="Test Title" img-src="https://picsum.photos/600/300/?image=25" img-alt="Test Image" img-top border-variant="light" class="text-center">
            <p>Test Text</p>
            <b-button>Test Button</b-button>
            <div slot="footer">
                <small class="text-muted">By: Test Cca</small>
            </div>
          </b-card>
          <b-card title="Test Title" img-src="https://picsum.photos/600/300/?image=25" img-alt="Test Image" img-top border-variant="light" class="text-center">
            <p>Test Text</p>
            <b-button>Test Button</b-button>
            <div slot="footer">
                <small class="text-muted">By: Test Cca</small>
            </div>
          </b-card>
          <b-card title="Test Title" img-src="https://picsum.photos/600/300/?image=25" img-alt="Test Image" img-top border-variant="light" class="text-center">
            <p>Test Text</p>
            <b-button>Test Button</b-button>
            <div slot="footer">
                <small class="text-muted">By: Test Cca</small>
            </div>
          </b-card>
        </b-card-group>
        </b-col>
      </b-row>
      <b-row>
        <b-col>
          <b-card title="Card Title">
            <p class="card-text">
              With supporting text below as a natural lead-in to additional content.
            </p>
            <b-button href="#" variant="primary">Go somewhere</b-button>
          </b-card>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data(){
    return{
      allEvents: {}
    };
  },
  methods: {
    participateInEvent() {

    }
  },
  mounted() {
    var self = this;
    this.axios.get("https://localhost:44362/api/events")
      .then(function (response) {
      console.log(response);
      this.allEvents = response.data;
      })
      .catch(function (error) {
        console.log(error);
      })
  }
}
</script>

<style scoped>

</style>
