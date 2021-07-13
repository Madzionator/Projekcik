<script>
  import { onMount } from "svelte";
  import {
    getHelloWorldList,
    postHelloWorld,
    removeHelloWorld,
  } from "../Services/HelloWorld";
  let texts = [];
  let singleTxt = "";

  onMount(async () => {
    Refresh();
  });

  async function handleClick() {
    await postHelloWorld({ text: singleTxt });
    await Refresh();
  }

  async function Refresh() {
    texts = await getHelloWorldList();
  }

  //   usuwanie:
  async function RemoveItem(id) {
    await removeHelloWorld(id);
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
    <!-- usuwanie -->
    <button on:click={() => RemoveItem(t.id)}> usun </button>
  </li>
{/each}
