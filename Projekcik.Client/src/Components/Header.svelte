<script>
  import { Link } from "svelte-navigator";
  import { token } from "../stores";

  $: isAuthenticated = $token;
</script>

<div class="header">
  <div class="container">
    <div class="global_head">
      <p>Projekcik</p>
    </div>
    <Link to="/">Home</Link>
    <Link to="manage">Zarządzaj</Link>

    <div class="xd" style="display: inline; float: right">
      {#if isAuthenticated}
        Zalogowano
        <Link to="logout">Wyloguj</Link>
      {:else}
        <Link to="register">Zarejestruj</Link>
        <Link to="login">Zaloguj</Link>
      {/if}
    </div>
  </div>
</div>

<style>
  .global_head {
    text-align: left;
    font-size: 24px;
    font-weight: bold;
  }

  .header {
    border-bottom: 1px solid gray;
    background-color: #eee;
  }
</style>
