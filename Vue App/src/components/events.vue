<template>
  <div class="events">
    <b-container>
      <br>
      <h3>My Events</h3>
      <br>
      <b-button
        v-b-modal.addEditModal
        type="submit"
        variant="outline-success"
        class="float-right"
        v-on:click.prevent.stop="loadAddModal()"
      >Add New Event</b-button>
      <br>
      <br>
      <b-table responsive bordered hover :items="items" :fields="fields">
        <template slot="index" slot-scope="data">{{data.index + 1}}</template>
        <template slot="actions" slot-scope="data">
          <b-button
            v-b-modal.addEditModal
            type="submit"
            variant="outline-warning"
            class="btn-block"
            v-on:click.prevent.stop="showEventInfo(data.item)"
          >Edit</b-button>
          <b-button
            v-b-modal.deleteModal
            type="submit"
            variant="outline-danger"
            class="btn-block"
            v-on:click.prevent.stop="saveEventId(data.item.eventId)"
          >Delete</b-button>
        </template>
      </b-table>
      <br>
      <b-modal
        id="deleteModal"
        size="sm"
        @ok="deleteEvent"
        title="Delete Event"
      >Are you sure that you want to delete this item?</b-modal>
      <b-modal
        id="addEditModal"
        @ok="addEditEvent(eventInfo)"
        @cancel="closeModal()"
        @close="closeModal()"
        size="lg"
        title="Add/Edit Event"
      >
        <b-container fluid>
          <div class="row">
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group id="eventNameLbl" label="Event Name" label-for="eventNameTbx">
                <b-form-input id="eventNameTbx" v-model="eventInfo.name" type="text"></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group id="eventTypeLbl" label="Event Type" label-for="eventTypeTbx">
                <b-form-input id="eventTypeTbx" v-model="eventInfo.type" type="text"></b-form-input>
              </b-form-group>
            </div>
          </div>
          <div class="row">
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group id="startDateLbl" label="Start Date" label-for="startDateTbx">
                <b-form-input id="startDateTbx" v-model="eventInfo.startDate" type="text"></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group id="endDateLbl" label="End Date" label-for="endDateTbx">
                <b-form-input id="endDateTbx" v-model="eventInfo.endDate" type="text"></b-form-input>
              </b-form-group>
            </div>
          </div>
          <div class="row">
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group id="contactLbl" label="Contact" label-for="contactTbx">
                <b-form-input id="contactTbx" v-model="eventInfo.contact" type="text"></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group id="ccaLbl" label="CCA" label-for="ccaTbx">
                <b-form-input id="ccaTbx" v-model="eventInfo.ccaId" type="text"></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group id="venueLbl" label="Venue" label-for="venueTbx">
                <b-form-input id="venueTbx" v-model="eventInfo.venue" type="text"></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group id="quotaLbl" label="Quota" label-for="quotaTbx">
                <b-form-input id="quotaTbx" v-model="eventInfo.quota" type="text"></b-form-input>
              </b-form-group>
            </div>
          </div>
          <b-form-group id="descriptionLbl" label="Description" label-for="descriptionTbx">
            <!--Bootstrap-vue Bug -> "Can't type in b-form-textarea" (Changed to bootstrap) -->
            <textarea
              class="form-control"
              v-model="eventInfo.description"
              id="descriptionTbx"
              rows="3"
              style="resize:none;"
            ></textarea>
          </b-form-group>
        </b-container>
      </b-modal>
    </b-container>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      fields: {
        index: "#",
        name: {
          key: "name",
          sortable: true
        },
        type: {
          key: "type",
          sortable: true
        },
        description: {
          key: "description",
          sortable: true
        },
        startDate: {
          key: "startDate",
          sortable: true
        },
        endDate: {
          key: "endDate",
          sortable: true
        },
        venue: {
          key: "venue",
          sortable: true
        },
        quota: {
          key: "quota",
          sortable: true
        },
        contact: {
          key: "contact",
          sortable: false
        },
        actions: "Actions"
      },
      items: [],
      eventInfo: {},
      addEventState: false,
      editEventState: false
    };
  },
  methods: {
    loadAddModal() {
      this.addEventState = true;
      this.eventInfo = {};
    },
    closeModal() {
      //Reset States & Clear Modal Bindings
      this.addEventState = false;
      this.editEventState = false;
      this.eventInfo = {};
    },
    showEventInfo(item) {
      this.editEventState = true;
      this.eventInfo = item;
    },
    saveEventId(id) {
      localStorage.setItem("dltEventId", id);
    },
    addEditEvent(eventInfo) {
        /* Temp fix*/
        eventInfo.createdBy = this.$route.params.userId;
        eventInfo.createdDate = new Date().toLocaleString();
        eventInfo.isDeleted = 0;

      if (this.addEventState == true) {
        eventInfo.updatedDate = new Date().toLocaleString();
        eventInfo.updatedBy = this.$route.params.userId;
        axios({
          method: "post",
          url: "https://localhost:44362/api/events/",
          data: eventInfo,
          config: { headers: { "Content-Type": "application/json" } }
        });
      } else if (this.editEventState == true) {
        axios({
          method: "put",
          url: "https://localhost:44362/api/events/" + eventInfo.eventId,
          data: eventInfo,
          config: { headers: { "Content-Type": "application/json" } }
        });
      }
      //Clear Modal
      this.eventInfo = {};
    },
    deleteEvent() {
      var id = localStorage.getItem("dltEventId");
      axios({
        method: "put",
        url:
          "https://localhost:44362/api/events/" +
          id +
          "/delete/" +
          this.$route.params.userId
      });
    }
  },
  mounted() {
    axios({
      method: "get",
      url:
        "https://localhost:44362/api/events/user/" + this.$route.params.userId
    }).then(response => {
      this.items = response.data;
    });
  }
};
</script>

