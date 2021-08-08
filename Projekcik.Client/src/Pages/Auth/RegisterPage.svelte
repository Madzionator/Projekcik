<script>
  import { Link } from "svelte-navigator";
  import AuthService from "../../Services/AuthService";

  let username = "";
  let password = "";
  let con_password = "";
  let accept = false;
  let errorMessage = false;
  let errorMessage2 = false;
  let signedUp = false;

  function Register() {
    if (password == con_password) {
      errorMessage = false;
      errorMessage2 = false;
      AuthService.register(username, password)
        .then((x) => {
          signedUp = true;
        })
        .catch((x) => {
          const response = x.response;
          errorMessage2 = true;
        });
    } else errorMessage = true;
  }
</script>

<div class="container">
  <h4>Sign up</h4>

  <div class="row">
    <div class="col-4"><p>Username</p></div>
    <div class="col-8"><input bind:value={username} type="text" /></div>

    <div class="col-4"><p>Password</p></div>
    <div class="col-8"><input bind:value={password} type="text" /></div>

    <div class="col-4"><p>Confirm Password</p></div>
    <div class="col-8"><input bind:value={con_password} type="text" /></div>

    <label>
      <input type="checkbox" bind:checked={accept} />
      I accept the Terms of Use & Privacy Policy
    </label>
  </div>

  <button on:click={Register} disabled={!accept}>Sign up</button>

  {#if errorMessage}
    <p>wprowadzone hasła są niezgodne!</p>
  {:else if errorMessage2}
    <p>login lub hasło niepoprawne</p>
  {/if}

  {#if signedUp}
    <p>
      rejestracja poprawna, proszę się zalogować:<Link to="/login">Log In</Link>
    </p>
  {/if}
</div>
