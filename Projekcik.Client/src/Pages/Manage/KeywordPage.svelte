<script>
  import { onMount } from "svelte";
  import KeywordService from "../../Services/KeywordService";

  let keywords = [];

  onMount(async () => {
    Refresh();
  });

  function Refresh() {
    KeywordService.getKeywordsStatsList().then((response) => {
      let top = response
        .filter((x) => x.id < 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      let rest = response
        .filter((x) => x.id >= 0)
        .sort((a, b) => (a.name > b.name ? 1 : b.name > a.name ? -1 : 0));
      keywords = top.concat(rest);
    });
  }

  function KeywordAdd() {
    let keyword = prompt("Podaj nazwę nowej umiejętności");
    KeywordService.createKeyword(keyword).then(() => Refresh());
  }

  function KeywordEdit(keyw) {
    let keyword = prompt("Podaj nową nazwę umiejętności", keyw.name);
    KeywordService.editKeyword(keyw.id, keyword).then(() => Refresh());
  }

  function KeywordDelete(keywId) {
    KeywordService.deleteKeyword(keywId).then(() => Refresh());
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="title">
    <i class="fas fa-chart-bar m-2" />Umiejętności
  </div>
  <p />
  <button class="btn btn-outline-primary dodaj" on:click={KeywordAdd}>
    <span class="fa fa-plus" aria-hidden="true" /> Dodaj miejsce
  </button>
  <p />
  <table class="table table-hover tabela">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Umiejętność</th>
        <th scope="col">Kandydaci</th>
        <th scope="col">Edytuj</th>
        <th scope="col">Usuń</th>
      </tr>
    </thead>
    <tbody>
      {#each keywords as keyw, i}
        <tr>
          <th scope="row">{i + 1}</th>
          <td>{keyw.name}</td>
          <td>{keyw.candidateCount}</td>
          <td>
            {#if keyw.id >= 0}
              <button class="btn" on:click={() => KeywordEdit(keyw)}>
                <span class="fa fa-edit" aria-hidden="true" />
              </button>
            {/if}
          </td>
          <td>
            {#if keyw.id >= 0}
              <button class="btn" on:click={() => KeywordDelete(keyw.id)}>
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
