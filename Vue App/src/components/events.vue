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
      <b-alert
        :show="dismissCountDown"
        dismissible
        fade
        variant="success"
        @dismissed="dismissCountDown=0"
        @dismiss-count-down="countDownChanged"
      >{{dismissMessage}}</b-alert>
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
        :title="modalTitle"
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
import moment from "moment";

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
      modalTitle: "",
      addEventState: false,
      editEventState: false,
      dismissMessage: "",
      dismissSecs: 2,
      dismissCountDown: 0,
      showDismissibleAlert: false
    };
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    loadAddModal() {
      this.addEventState = true;
      this.editEventState = false;
      this.eventInfo = {};
      this.modalTitle = "Add Event";
    },
    closeModal() {
      //Reset States & Clear Modal Bindings
      this.addEventState = false;
      this.editEventState = false;
      this.eventInfo = {};
    },
    showEventInfo(item) {
      this.addEventState = false;
      this.editEventState = true;
      this.eventInfo = item;
      this.modalTitle = "Edit Event";
    },
    saveEventId(id) {
      localStorage.setItem("dltEventId", id);
    },
    addEditEvent(eventInfo) {
      //Save formatted datetime
      var startDate = eventInfo.startDate;
      var endDate = eventInfo.endDate;

      // Revert datetime to ISO 8601 format */
      // Added 8 hours to offset UTC time */
      // Another solution will be to include moment-timezone
      // but it's unnecessary as we are working with 1 timezone only
      eventInfo.startDate = moment(eventInfo.startDate).add(8,'hours').toISOString();
      eventInfo.endDate = moment(eventInfo.endDate).add(8,'hours').toISOString();
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
        this.dismissMessage = "Event " + eventInfo.name + " created.";
      } else if (this.editEventState == true) {
        axios({
          method: "put",
          url: "https://localhost:44362/api/events/" + eventInfo.eventId,
          data: eventInfo,
          config: { headers: { "Content-Type": "application/json" } }
        });
        this.dismissMessage = "Event: " + eventInfo.name + " updated.";
      }

      //Update ISO8601 datetime back to formatted datetime.
      eventInfo.startDate = startDate;
      eventInfo.endDate = endDate;
      
      //Clear Modal
      this.eventInfo = {};
      this.dismissCountDown = this.dismissSecs;
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
      this.dismissMessage = "Event deleted.";
      this.dismissCountDown = this.dismissSecs;
    }
  },
  mounted() {
    axios({
      method: "get",
      url:
        "https://localhost:44362/api/events/user/" + this.$route.params.userId
    }).then(response => {
      this.items = response.data;
      //Update array and format date time using MomentJs
      for (let item of this.items) {
        item.startDate = moment(new Date(item.startDate)).format(
          "YYYY-MM-DD HH:mm"
        );
        item.endDate = moment(new Date(item.endDate)).format(
          "YYYY-MM-DD HH:mm"
        );
      }
    });
  }
};
</script>

