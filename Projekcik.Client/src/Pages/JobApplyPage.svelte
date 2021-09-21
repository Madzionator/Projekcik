<script>
  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import JobService from "../Services/JobService";

  export let id; // job id
  let job;
  let firstName;
  let lastName;
  let phoneNumber;
  let emailAddress;
  let comment;
  let cv;

  onMount(async () => {
    JobService.getJob(id)
      .then((response) => {
        job = response;
        console.log(job);
      })
      .catch((response) => {
        toast.push("oferta nie istnieje");
        navigate("/", { replace: true });
      });
  });

  function Apply() {
    console.log("apply");
  }
</script>

{#if job}
  <div class="container prostokat p-3 p-lg-5 mx-auto my-5">
    <div class="mb-3 title">
      <i class="fas fa-briefcase m-2" />Aplikacja na stanowisko:
      <b>{job.title}</b>
      - {job.companyName}
    </div>
    <div class="dane">
      <div class="mb-2 text">Twoje dane</div>
      <div class="row">
        <div class="col-12 col-md-12 col-lg-6 mb-3">
          <label for="firstName" class="form-label">Imię:</label>
          <input
            type="text"
            class="form-control"
            id="firstName"
            bind:value={firstName}
            placeholder="Twoje imię"
          />
        </div>
        <div class="col-12 col-md-12 col-lg-6 mb-3">
          <label for="lastName" class="form-label">Nazwisko:</label>
          <input
            type="text"
            class="form-control"
            id="lastName"
            bind:value={lastName}
            placeholder="Twoje nazwisko"
          />
        </div>
      </div>
    </div>

    <div class="row">
      <div class="col-12 col-md-12 col-lg-6 mb-3">
        <label for="phoneNumber" class="form-label">Telefon kontaktowy:</label>
        <input
          type="tel"
          class="form-control"
          id="phoneNumber"
          bind:value={phoneNumber}
          placeholder="Twój numer telefonu"
        />
      </div>
      <div class="col-12 col-md-12 col-lg-6 mb-3">
        <label for="emailAddress" class="form-label">Adres email:</label>
        <input
          type="email"
          class="form-control"
          id="emailAddress"
          bind:value={emailAddress}
          placeholder="Twój adres email"
        />
      </div>

      <div class="mb-3">
        <label for="comment" class="form-label">Komentarz:</label>
        <textarea
          type="text"
          class="form-control"
          id="comment"
          bind:value={comment}
          placeholder="Możesz zostawić komentarz dla HR."
        />
      </div>

      <div class=" mb-3">
        <label for="cv" class="form-label">CV:</label>
        <input
          type="file"
          class="form-control"
          id="cv"
          accept="application/pdf"
          bind:value={cv}
        />
      </div>

      <div class="mt-3">
        <button class="btn btn-success apply" on:click={Apply}>
          Wyślij zgłoszenie
        </button>
      </div>
    </div>
  </div>
{/if}

<style lang="scss">
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .dane {
    margin: 3px;
  }
  .title {
    @import "../global.scss";
    font-size: large;
    border: 1px solid black;
    background-color: rgba($green2, 0.6);
    border-radius: 3px;
  }
  .text {
    font-weight: bold;
    font-size: large;
  }
  .apply {
    @import "../global.scss";
    width: 200px;
    background-color: rgba($green2, 0.6);
    color: black;
    &:hover,
    &:focus {
      background-color: rgba($green1, 0.8);
      color: black;
    }
  }
</style>
