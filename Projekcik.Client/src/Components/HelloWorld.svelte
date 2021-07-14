<script>
  import { onMount } from "svelte";
  import HelloWorldService from "../Services/HelloWorldService";

  let texts = [];
  let singleTxt = "";

  onMount(async () => {
    Refresh();
  });

  async function handleClick() {
    await HelloWorldService.postHelloWorld({ text: singleTxt });
    await Refresh();
  }

  async function Refresh() {
    texts = await HelloWorldService.getHelloWorldList();
  }

  async function RemoveItem(id) {
    await HelloWorldService.removeHelloWorld(id);
    await Refresh();
  }

  async function EditItem(id) {
    await HelloWorldService.editHelloWorld(id, { text: singleTxt });
    await Refresh();
  }
</script>

<div>
  <input bind:value={singleTxt} type="text" />

  <button on:click={handleClick}> wyślij </button>
</div>

{#each texts as t}
  <li>
    {t.value}
    <button on:click={() => RemoveItem(t.id)}> usun </button>
    <button on:click={() => EditItem(t.id)}> edytuj </button>
  </li>
{/each}
