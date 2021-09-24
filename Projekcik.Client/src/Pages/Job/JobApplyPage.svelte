<script>
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import CandidateService from "../../Services/CandidateService";
  import JobService from "../../Services/JobService";

  export let id; // job id
  let job = "";
  let firstName = "";
  let lastName = "";
  let phoneNumber = "";
  let emailAddress = "";
  let comment = "";
  let cv = [];

  let validationErrors = [];

  onMount(async () => {
    JobService.getJob(id)
      .then((response) => {
        job = response;
      })
      .catch((response) => {
        toast.push("oferta nie istnieje");
        navigate("/", { replace: true });
      });
  });

  function Apply() {
    const formData = new FormData();
    formData.append("file", cv[0]);
    formData.append("firstName", firstName);
    formData.append("lastName", lastName);
    formData.append("phoneNumber", phoneNumber);
    formData.append("emailAddress", emailAddress);
    formData.append("comment", comment);
    CandidateService.applyForJob(id, formData)
      .then((response) => {
        navigate("/job/thanksforapplying", { replace: true });
      })
      .catch((x) => {
        validationErrors = x.response.data.errors;
        toast.push("Nie udało się aplikować 😿");
      });
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  {#if job}
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
          {#if validationErrors.firstName}
            <div class="error">
              {validationErrors.firstName.join(", ")}
            </div>
          {/if}
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
          {#if validationErrors.lastName}
            <div class="error">
              {validationErrors.lastName.join(", ")}
            </div>
          {/if}
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
        {#if validationErrors.phoneNumber}
          <div class="error">
            {validationErrors.phoneNumber.join(", ")}
          </div>
        {/if}
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
        {#if validationErrors.emailAddress}
          <div class="error">
            {validationErrors.emailAddress.join(", ")}
          </div>
        {/if}
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
        {#if validationErrors.comment}
          <div class="error">
            {validationErrors.comment.join(", ")}
          </div>
        {/if}
      </div>

      <div class=" mb-3">
        <label for="cv" class="form-label">CV:</label>
        <input
          type="file"
          class="form-control"
          id="cv"
          accept="application/pdf"
          bind:files={cv}
        />
        {#if validationErrors.file}
          <div class="error">
            {validationErrors.file.join(", ")}
          </div>
        {/if}
      </div>

      <div class="mt-3">
        <button class="btn btn-success apply" on:click={Apply}>
          Wyślij zgłoszenie
        </button>
      </div>
    </div>
  {:else}
    <div class="d-flex justify-content-center">
      <div class="spinner-border" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    </div>
  {/if}
</div>

<style lang="scss">
  @import "src/global.scss";
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(black, 0.2);
  }
  .dane {
    margin: 3px;
  }
  .title {
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
    width: 200px;
    background-color: rgba($green2, 0.6);
    color: black;
    &:hover,
    &:focus {
      background-color: rgba($green1, 0.8);
      color: black;
    }
  }
  .error {
    color: crimson;
    font-size: small;
    padding-top: 3px;
  }
</style>
