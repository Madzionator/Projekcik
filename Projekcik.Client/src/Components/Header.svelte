<script>
  import { Link } from "svelte-navigator";
</script>

<div class="header">
  <div class="container">
    <div class="global_head">
      <p>Projekcik</p>
    </div>
    <Link to="/">Home</Link>
    <Link to="witam">Witam</Link>
    <Link to="pozdrawiam">Pozdrawiam</Link>
    <Link to="helloworld">HelloWorld</Link>
  </div>
</div>

<style>
  .global_head {
    text-align: left;
    font-size: 24px;
    font-weight: bold;
    margin-top: 5px;
  }

  .header {
    border-bottom: 1px solid gray;
  }
</style>
