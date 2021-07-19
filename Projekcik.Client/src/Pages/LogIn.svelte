<script>
  import { navigate } from "svelte-navigator";
  import AuthService from "../Services/AuthService";

  let username = "";
  let password = "";
  let errorMessage = false;

  function LogIn() {
    AuthService.login(username, password)
      .then((x) => {
        navigate("/", { replace: true });
      })
      .catch((x) => {
        const response = x.response;
        errorMessage = true;
      });
  }
</script>

<div class="container">
  <h4>Sign up</h4>

  <div class="row">
    <div class="col-4"><p>Username</p></div>
    <div class="col-8"><input bind:value={username} type="text" /></div>

    <div class="col-4"><p>Password</p></div>
    <div class="col-8"><input bind:value={password} type="text" /></div>
  </div>

  <button
    on:click={LogIn}
    disabled={username.length == 0 || password.length == 0}
    >Log in
  </button>

  {#if errorMessage}
    <p>login lub hasło niepoprawne</p>
  {/if}
</div>
