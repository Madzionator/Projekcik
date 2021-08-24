<script>
  import { Link } from "svelte-navigator";
  import AuthService from "../Services/AuthService";

  const isLogged = AuthService.isLogged();
</script>

<div class="header">
  <div class="container">
    <div class="global_head">
      <p>Projekcik</p>
    </div>
    <Link to="/">Home</Link>
    <Link to="manage">Manage</Link>
    {#if isLogged}
      <Link to="logout">Log Out</Link>
    {:else}
      <Link to="register">Register</Link>
      <Link to="login">Log In</Link>
    {/if}
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
    background-color: #eee;
  }
</style>
