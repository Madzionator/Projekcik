<script>
  export let title = "";
  export let description = "";
  export let minimumSalary;
  export let maximumSalary;
  export let companyName;
  export let onEdit = false;

  export let validationErrors = {};
  export let onSave;

  function saveJob() {
    onSave({
      title,
      description,
      minimumSalary,
      maximumSalary,
      companyName,
    });
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="mb-3">
    <div class="title">
      {#if onEdit}
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

  <div class="mb-3">
    <div class="strip">wynagrodzenie od - do</div>
    <input class="input_num" bind:value={minimumSalary} type="number" /> -
    <input class="input_num" bind:value={maximumSalary} type="number" />
  </div>

  <p />
  <div>
    <button type="button" class="btn btn-secondary zapisz" on:click={saveJob}>
      zapisz
    </button>
  </div>
</div>

<style lang="scss">
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
    background-color: rgba(35, 199, 150, 0.5);
    border-radius: 3px;
  }
  .strip {
    font-size: medium;
    background-color: rgba(35, 199, 150, 0.3);
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
  }
  .zapisz {
    width: 100px;
    background-color: rgba(35, 199, 150, 0.5);
    color: black;
  }
  .zapisz:hover {
    background-color: rgba(0, 156, 109, 0.65);
    color: black;
  }
  .error {
    color: crimson;
    font-size: small;
    padding-top: 3px;
  }
</style>
