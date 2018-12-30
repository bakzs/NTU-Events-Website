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
            class="btn-block fas fa-edit"
            v-on:click.prevent.stop="showEventInfo(data.item)"
          ></b-button>
          <br>
          <br>
          <b-button
            v-b-modal.deleteModal
            type="submit"
            variant="outline-danger fas fa-trash"
            class="btn-block"
            v-on:click.prevent.stop="saveEventId(data.item.eventId)"
          ></b-button>
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
        ref="addEditModal"
        @ok.prevent="addEditEvent(eventInfo, $event)"
        @hide="closeModal()"
        size="lg"
        :title="modalTitle"
        :no-close-on-backdrop="true"
        :no-close-on-esc="true"
      >
        <b-container fluid>
          <div class="row validateInputs">
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="eventNameLbl"
                :invalid-feedback="errors.first('Event Name')"
                :state="!errors.has('Event Name')"
                label="Event Name"
                label-for="eventNameTbx"
              >
                <b-form-input
                  id="eventNameTbx"
                  v-model="eventInfo.name"
                  :state="!errors.has('Event Name')"
                  v-validate="'required|min:10|max:40'"
                  type="text"
                  name="Event Name"
                ></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="eventTypeLbl"
                :invalid-feedback="errors.first('Event Type')"
                :state="!errors.has('Event Type')"
                label="Event Type"
                label-for="eventTypeTbx"
              >
                <b-form-input
                  id="eventTypeTbx"
                  v-model="eventInfo.type"
                  :state="!errors.has('Event Type')"
                  v-validate="'required|min:5|max:20'"
                  type="text"
                  name="Event Type"
                ></b-form-input>
              </b-form-group>
            </div>
          </div>
          <div class="row">
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="startDateLbl"
                :invalid-feedback="errors.first('Start Date')"
                :state="!errors.has('Start Date')"
                label="Start Date"
                label-for="startDateDp"
              >
                <date-picker
                  id="startDateDp"
                  v-model="eventInfo.startDate"
                  :state="!errors.has('Start Date')"
                  v-validate="'required|date_format:YYYY-MM-DD HH:mm'"
                  :class="this.$validator.errors.has('Start Date') ? 'is-invalid' : 'is-valid'"
                  :config="options.start"
                  name="Start Date"
                ></date-picker>
              </b-form-group>
            </div>
            <div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="endDateLbl"
                :invalid-feedback="errors.first('End Date')"
                :state="!errors.has('End Date')"
                label="End Date"
                label-for="endDateDp"
              >
                <date-picker
                  id="endDateDp"
                  v-model="eventInfo.endDate"
                  :state="!errors.has('End Date')"
                  v-validate="'required|date_format:YYYY-MM-DD HH:mm'"
                  :class="this.$validator.errors.has('End Date') ? 'is-invalid' : 'is-valid'"
                  :config="options.end"
                  name="End Date"
                ></date-picker>
              </b-form-group>
            </div>
          </div>
          <div class="row">
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="contactLbl"
                :invalid-feedback="errors.first('Contact')"
                :state="!errors.has('Contact')"
                label="Contact"
                label-for="contactTbx"
              >
                <b-form-input
                  id="contactTbx"
                  v-model="eventInfo.contact"
                  :state="!errors.has('Contact')"
                  v-validate="'required|numeric|min:8|max:8'"
                  type="text"
                  name="Contact"
                ></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="ccaLbl"
                :invalid-feedback="errors.first('CCA')"
                :state="!errors.has('CCA')"
                label="CCA"
                label-for="ccaTbx"
              >
                <b-form-select
                  id="ccaTbx"
                  v-model="eventInfo.ccaId"
                  :options="ccaList"
                  :state="!errors.has('CCA')"
                  v-validate="'required'"
                  name="CCA"
                ></b-form-select>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="venueLbl"
                :invalid-feedback="errors.first('Venue')"
                :state="!errors.has('Venue')"
                label="Venue"
                label-for="venueTbx"
              >
                <b-form-input
                  id="venueTbx"
                  v-model="eventInfo.venue"
                  :state="!errors.has('Venue')"
                  v-validate="'required|min:5|max:30'"
                  type="text"
                  name="Venue"
                ></b-form-input>
              </b-form-group>
            </div>
            <div class="col-xl-3 col-lg-3 col-md-12 col-sm-12 col-12">
              <b-form-group
                id="quotaLbl"
                :invalid-feedback="errors.first('Quota')"
                :state="!errors.has('Quota')"
                label="Quota"
                label-for="quotaTbx"
              >
                <b-form-input
                  id="quotaTbx"
                  v-model="eventInfo.quota"
                  :state="!errors.has('Quota')"
                  v-validate="'required|numeric|min:1|max:4'"
                  type="text"
                  name="Quota"
                ></b-form-input>
              </b-form-group>
            </div>
          </div>
          <b-form-group
            id="descriptionLbl"
            label="Description"
            :invalid-feedback="errors.first('Description')"
            :state="!errors.has('Description')"
            label-for="descriptionTbx"
          >
            <b-form-textarea
              id="descriptionTbx"
              v-model="eventInfo.description"
              :state="!errors.has('Description')"
              v-validate="'required|min:20|max:120'"
              :class="this.$validator.errors.has('Description') ? 'is-invalid' : 'is-valid'"
              :rows="3"
              :max-rows="6"
              :no-resize="true"
              name="Description"
            ></b-form-textarea>
          </b-form-group>
        </b-container>
      </b-modal>
    </b-container>
  </div>
</template>

<script>
export default {
  data() {
    return {
      date: new Date(),
      options: {
        format: "YYYY-MM-DD HH:mm",
        useCurrent: false,
        start: {
          format: "YYYY-MM-DD HH:mm",
          useCurrent: false,
          showClear: true,
          showClose: true,
          maxDate: false
        },
        end: {
          format: "YYYY-MM-DD HH:mm",
          useCurrent: false,
          showClear: true,
          showClose: true,
          minDate: false
        }
      },
      fields: {
        index: {
          label: "#"
        },
        name: {
          key: "name",
          sortable: true
        },
        type: {
          key: "type",
          sortable: true
        },
        description: {
          key: "description"
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
        cca: {
          key: "ccaname",
          label: "CCA"
        },
        actions: {
          label: "Actions"
        }
      },
      items: [],
      ccaList: [],
      selected: null,
      eventInfo: {},
      modalTitle: "",
      addEventState: false,
      editEventState: false,
      dismissMessage: "",
      dismissSecs: 2,
      dismissCountDown: 0,
      showDismissibleAlert: false,
      okButtonClicked: false,
      detailShow: false
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
      this.options.showClear = true;
      //JQuery remove all 'is-valid' in div child
      //Workaround for Validation Messages Displaying on Page Load
      $("#addEditModal")
        .find("*")
        .removeClass("is-valid");
    },
    closeModal() {
      //Three ways to close the modal -- 1. Ok button, 2. Cancel Button, 3. Header - Cross Button
      //For 1 --> Don't do anything
      //For 2 && 3 --> Reset States & Clear Modal Bindings & Clear validation
      if (this.okButtonClicked == true) {
        this.okButtonClicked = false;
      } else {
        //Reset States & Clear Modal Bindings & Clear validation
        this.addEventState = false;
        this.editEventState = false;
        this.eventInfo = {};
        this.$validator.reset();
      }
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
      this.okButtonClicked = true;
      this.$validator
        .validateAll()
        .then(result => {
          if (!result) {
            //Validation failed
            //Prevent the modal from closing
            event.preventDefault();
          } else {
            //Save formatted datetime
            var startDate = eventInfo.startDate;
            var endDate = eventInfo.endDate;
            // Revert datetime to ISO 8601 format */
            eventInfo.startDate = this.$moment(
              eventInfo.startDate
            ).toISOString();
            eventInfo.endDate = this.$moment(eventInfo.endDate).toISOString();
            /* Temp fix*/
            eventInfo.createdBy = this.$route.params.userId;
            eventInfo.createdDate = new Date().toLocaleString();
            eventInfo.isDeleted = 0;
            if (this.addEventState == true) {
              eventInfo.updatedDate = new Date().toLocaleString();
              eventInfo.updatedBy = this.$route.params.userId;

              this.axios({
                method: "post",
                url: "https://localhost:44362/api/events/",
                data: eventInfo,
                config: { headers: { "Content-Type": "application/json" } }
              }).catch(error => {
                alert("Error encountered while creating events");
                console.log(error);
              });
              this.dismissMessage = "Event " + eventInfo.name + " created.";
            } else if (this.editEventState == true) {
              this.axios({
                method: "put",
                url: "https://localhost:44362/api/events/" + eventInfo.eventId,
                data: eventInfo,
                config: { headers: { "Content-Type": "application/json" } }
              }).catch(error => {
                alert("Error encountered while editing event");
                console.log(error);
              });
              this.dismissMessage = "Event: " + eventInfo.name + " updated.";
            }
            //Update ISO8601 datetime back to formatted datetime.
            eventInfo.startDate = startDate;
            eventInfo.endDate = endDate;
            //Clear Modal, Hide Modal, Reset Validation
            this.eventInfo = {};
            this.dismissCountDown = this.dismissSecs;
            this.$refs.addEditModal.hide();
            this.$validator.reset();
          }
        })
        .catch(() => {});
    },
    deleteEvent() {
      var id = localStorage.getItem("dltEventId");
      this.axios({
        method: "put",
        url:
          "https://localhost:44362/api/events/" +
          id +
          "/delete/" +
          this.$route.params.userId
      }).catch(error => {
        alert("Error encountered while deleting event");
        console.log(error);
      });
      this.dismissMessage = "Event deleted.";
      this.dismissCountDown = this.dismissSecs;
    }
  },
  mounted() {
    //Get list of CCA participation
    this.axios({
      method: "get",
      url: "https://localhost:44362/api/ccas"
    })
      .then(response => {
        for (var i = 0; i < response.data.length; i++) {
          var item = {
            value: response.data[i].ccaId,
            text: response.data[i].name
          };
          this.ccaList.push(item);
        }
      })
      .catch(error => {
        alert("Error encountered while retrieving cca");
        console.log(error);
      });

    //Get user events list
    this.axios({
      method: "get",
      url:
        "https://localhost:44362/api/events/createdby/" +
        this.$route.params.userId
    })
      .then(response => {
        this.items = response.data;
        //Update array and format date time using MomentJs
        for (let item of this.items) {
          item.startDate = this.$moment(new Date(item.startDate)).format(
            "YYYY-MM-DD HH:mm"
          );
          item.endDate = this.$moment(new Date(item.endDate)).format(
            "YYYY-MM-DD HH:mm"
          );
          for (var i = 0; i < this.ccaList.length; i++) {
            if (item.ccaId == this.ccaList[i].value) {
              Object.assign(item, { ccaname: this.ccaList[i].text });
            }
          }
        }
      })
      .catch(error => {
        alert("Error encountered while retrieving events");
        console.log(error);
      });
  }
};
</script>
<style>
/* Default table properties */
table {
  font: normal 12px arial;
  width: 100%;
}

td {
  max-width: 100px;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}
/* Media Queries - Make table become cards*/
@media only screen and (max-width: 760px),
  (min-device-width: 768px) and (max-device-width: 1024px) {
  table,
  thead,
  tbody,
  th,
  td,
  tr {
    display: block;
    max-width: 100%;
  }

  /* Remove hover */
  .table-hover tbody tr:hover td,
  .table-hover tbody tr:hover {
    background-color: #ffffff;
  }
  /*Shift table headers columns away from view*/
  thead tr {
    position: absolute;
    top: -9999px;
    left: -9999px;
  }

  /*Set the table row spacing and border*/
  tr {
    border-bottom: 1px solid #ccc;
    margin-bottom: 30px;
  }

  td {
    position: relative;
  }

  /*Adjust and set the position of the table title*/
  td:before {
    position: absolute;
    top: 5px;
    left: 10px;
    font-weight: bold;
  }

  .table th,
  .table td {
    padding: 1.5rem !important;
  }

  td:nth-of-type(1):before {
    content: "#";
  }
  td:nth-of-type(2):before {
    content: "Name";
  }
  td:nth-of-type(3):before {
    content: "Type";
  }
  td:nth-of-type(4):before {
    content: "Description";
  }
  td:nth-of-type(5):before {
    content: "Start Date";
  }
  td:nth-of-type(6):before {
    content: "End Date";
  }
  td:nth-of-type(7):before {
    content: "Venue";
  }
  td:nth-of-type(8):before {
    content: "Quota";
  }
  td:nth-of-type(9):before {
    content: "Contact";
  }
  td:nth-of-type(10):before {
    content: "CCA";
  }
}
</style>