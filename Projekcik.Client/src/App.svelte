<script>
  import Header from "./Header.svelte";
  import Banner from "./Banner.svelte";
  import Rectangle from "./Rectangle.svelte";

  let tx = [
    { content: "tekst1" },
    { content: "tekst2" },
    { content: "tekst3" },
    { content: "🐻" },
    { content: "🐗" },
    { content: "X" },
    { content: "❤" },
    { content: "👌" },
  ];
</script>

<Header />
<Banner />

<div class="container prostokaciki">
  <div class="row">
    {#each tx as t}
      <div class="col-12 col-xs-12 col-md-6 col-lg-3">
        <Rectangle content={t.content} />
      </div>
    {/each}
  </div>
</div>

<style>
  .prostokaciki > .row > [class*="col-"] {
    padding: 0;
  }
</style>
