<script>
  import { onMount } from "svelte";
  import LocationService from "../Services/LocationService";

  export let title = "";
  export let description = "";
  export let minimumSalary;
  export let maximumSalary;
  export let companyName;
  export let locations = [];
  let locationIds = locations.map((x) => x.id);
  export let isEdit = false;

  export let validationErrors = {};
  export let onSave;

  let allLocations = [];

  onMount(async () => {
    LocationService.getLocationsList().then((response) => {
      let top = response
        .filter((x) => x.id < 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      let rest = response
        .filter((x) => x.id >= 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      allLocations = top.concat(rest);
    });
  });

  function saveJob() {
    onSave({
      title,
      description,
      minimumSalary,
      maximumSalary,
      companyName,
      locationIds,
    });
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="mb-3">
    <div class="title">
      {#if isEdit}
        <i class="fas fa-briefcase m-2" />Edytuj ofertę pracy:
      {:else}
        <i class="fas fa-briefcase m-2" />Dodaj ofertę pracy:
      {/if}
    </div>
  </div>
  <div class="strip">tytuł</div>
  <div class="mb-3">
    <input class="input_text" bind:value={title} type="text" />
    {#if validationErrors.Title}
      <div class="error">
        {validationErrors.Title.join(", ")}
      </div>
    {/if}
  </div>

  <div class="mb-3">
    <div class="strip">opis</div>
    <textarea
      class="textarea_description"
      bind:value={description}
      type="text"
    />
    {#if validationErrors.Description}
      <div class="error">
        {validationErrors.Description.join(", ")}
      </div>
    {/if}
  </div>

  <div class="mb-3">
    <div class="strip">firma</div>
    <input class="input_text" bind:value={companyName} type="text" />
    {#if validationErrors.CompanyName}
      <div class="error">
        {validationErrors.CompanyName.join(", ")}
      </div>
    {/if}
  </div>

  {#if allLocations}
    <div class="mb-3">
      <div class="strip">lokalizacja</div>

      {#each allLocations as loc}
        <div class="form-check col-6">
          <input
            class="form-check-input"
            id="xd"
            type="checkbox"
            value={loc.id}
            bind:group={locationIds}
          />
          <label class="form-check-label" for="xd">
            {loc.name}
          </label>
        </div>
      {/each}
      {#if validationErrors.LocationIds}
        <div class="error">
          {validationErrors.LocationIds.join(", ")}
        </div>
      {/if}
    </div>
  {/if}

  <div class="mb-3">
    <div class="strip">wynagrodzenie od - do</div>
    <input class="input_num" bind:value={minimumSalary} type="number" /> -
    <input class="input_num" bind:value={maximumSalary} type="number" />
    {#if validationErrors.MinimumSalary}
      <div class="error">
        {validationErrors.MinimumSalary.join(", ")}
      </div>
    {/if}
    {#if validationErrors.MaximumSalary}
      <div class="error">
        {validationErrors.MaximumSalary.join(", ")}
      </div>
    {/if}
  </div>

  <p />
  <div>
    <button type="button" class="btn btn-secondary zapisz" on:click={saveJob}>
      Zapisz
    </button>
  </div>
</div>

<style lang="scss">
  $seaColor: rgb(35, 199, 150);
  $darkSeaColor: rgba(0, 156, 109, 0.7);

  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .title {
    font-size: large;
    border: 1px solid black;
    background-color: rgba($seaColor, 0.5);
    border-radius: 3px;
  }
  .strip {
    font-size: medium;
    background-color: rgba($seaColor, 0.3);
    border-radius: 3px;
    width: 200px;
    padding: 0 0.2rem;
    margin-bottom: 0.3rem;
  }
  .input_text {
    width: 200px;
  }
  .input_num {
    width: 120px;
  }
  .textarea_description {
    width: 100%;
    height: 150px;
    min-height: 50px;
  }
  .zapisz {
    width: 100px;
    background-color: rgba($seaColor, 0.5);
    color: black;
    &:hover,
    &:focus {
      background-color: $darkSeaColor;
      color: black;
    }
  }
  .error {
    color: crimson;
    font-size: small;
    padding-top: 3px;
  }
</style>
