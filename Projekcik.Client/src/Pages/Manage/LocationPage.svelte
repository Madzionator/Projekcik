<script>
  import { onMount } from "svelte";
  import LocationService from "../../Services/LocationService.js";

  let locations = [];

  onMount(async () => {
    Refresh();
  });

  function Refresh() {
    LocationService.getLocationsSatsList().then((response) => {
      let top = response
        .filter((x) => x.id < 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      let rest = response
        .filter((x) => x.id >= 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      locations = top.concat(rest);
    });
  }

  function LocationAdd() {
    let location = prompt("Podaj nazwę nowej lokalizacji");
    LocationService.createLocation(location).then(() => Refresh());
  }

  function LocationEdit(loc) {
    let location = prompt("Podaj nową nazwę lokalizacji", loc.name);
    LocationService.editLocation(loc.id, location).then(() => Refresh());
  }

  function LocationDelete(loc) {
    console.log("delete");
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="title">
    <i class="fas fa-map-marker-alt m-2" />Miejsca
  </div>
  <p />
  <button class="btn btn-outline-primary dodaj" on:click={LocationAdd}>
    <span class="fa fa-plus" aria-hidden="true" /> Dodaj miejsce
  </button>
  <p />
  <table class="table table-hover tabela">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Miejsce</th>
        <th scope="col">Oferty Pracy</th>
        <th scope="col">Kandydaci</th>
        <th scope="col">Edytuj</th>
        <th scope="col">Usuń</th>
      </tr>
    </thead>
    <tbody>
      {#each locations as loc, i}
        <tr>
          <th scope="row">{i + 1}</th>
          <td>{loc.name}</td>
          <td>{loc.jobCount}</td>
          <td>tu też</td>
          <td>
            {#if loc.id >= 0}
              <button class="btn" on:click={() => LocationEdit(loc)}>
                <span class="fa fa-edit" aria-hidden="true" />
              </button>
            {/if}
          </td>
          <td>
            {#if loc.id >= 0}
              <button class="btn" on:click={() => LocationDelete(loc.id)}>
                <span class="fa fa-times" aria-hidden="true" />
              </button>
            {/if}
          </td>
        </tr>
      {/each}
    </tbody>
  </table>
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
    text-align: center;
    border: 1px solid black;
    border-radius: 5px;
    background-color: rgba(76, 145, 94, 0.5);
  }
  .tabela {
    text-align: center;
  }
</style>
