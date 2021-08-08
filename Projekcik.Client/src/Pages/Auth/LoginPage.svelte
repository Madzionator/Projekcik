<script>
  import { navigate } from "svelte-navigator";
  import AuthService from "../../Services/AuthService";
  import { toast } from "@zerodevx/svelte-toast";

  let username = "";
  let password = "";
  let errorMessage = false;
  let busy = false;

  function LogIn() {
    busy = true;
    AuthService.login(username, password)
      .then((x) => {
        navigate("/", { replace: true });
        busy = false;
        toast.push("Zalogowano");
      })
      .catch((x) => {
        errorMessage = true;
        busy = false;
        toast.push("Nie udało się zalogować");
      });
  }
</script>

<div class="container">
  <h4>Sign in</h4>

  <div class="row">
    <div class="col-4"><p>Username</p></div>
    <div class="col-8"><input bind:value={username} type="text" /></div>

    <div class="col-4"><p>Password</p></div>
    <div class="col-8"><input bind:value={password} type="text" /></div>
  </div>

  <div>
    <button
      on:click={LogIn}
      disabled={username.length == 0 || password.length == 0}
      >Log in
    </button>
  </div>

  {#if busy}
    <div class="spinner-border" role="status">
      <span class="visually-hidden">Loading...</span>
    </div>
  {/if}

  {#if errorMessage}
    <div>
      <p>login lub hasło niepoprawne</p>
    </div>
  {/if}
</div>
