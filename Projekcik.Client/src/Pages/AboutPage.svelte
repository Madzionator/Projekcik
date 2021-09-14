<script>
  import Banner from "../Components/Banner.svelte";
  import Rectangle from "../Components/Rectangle.svelte";

  let tx = [
    { content: "tekst1" },
    { content: "tekst2" },
    { content: "tekst3" },
    { content: "X" },
    { content: "🐻" },
    { content: "😽" },
    { content: "🐗" },
    { content: "❤" },
    { content: "where" },
    { content: "teleport" },
    { content: "*(>^.^)>" },
    { content: "<(^.^<)*" },
  ];
</script>

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
