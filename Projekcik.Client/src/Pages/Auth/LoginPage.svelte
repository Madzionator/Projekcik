<script>
  import { navigate } from "svelte-navigator";
  import AuthService from "../../Services/AuthService";
  import { toast } from "@zerodevx/svelte-toast";
  import qs from "query-string";
  let logo = "./images/logo.png";

  let username = "";
  let password = "";
  let errorMessage = false;
  let busy = false;

  function LogIn() {
    busy = true;
    AuthService.login(username, password)
      .then((x) => {
        busy = false;
        const queryparams = qs.parse(location.search);
        const href = queryparams["href"];
        if (href) navigate(href, { replace: true });
        else navigate("/", { replace: true });

        toast.push("Zalogowano");
      })
      .catch((x) => {
        errorMessage = true;

        busy = false;

        toast.push("Nie udało się zalogować");
      });
  }
</script>

<head>
  <style>
    body {
      background-color: #eee;
    }
  </style>
</head>

<div class="container prostokat py-3 px-3 py-5">
  <img src={logo} alt="logo" width="60%" />
  <hr />
  <div class="napis">
    <h3>Panel administracyjny</h3>
  </div>
  <div class="pola">
    <div class="form-group">
      <label for="InputLogin1">Login</label>
      <input
        bind:value={username}
        class="form-control"
        id="InputLogin1"
        placeholder="Twój login"
      />
      <p />
      <label for="InputPassword1">Hasło</label>
      <input
        type="password"
        bind:value={password}
        class="form-control"
        id="InputPassword1"
        placeholder="Twoje hasło"
      />
    </div>
  </div>

  <div>
    <button
      class="btn btn-success mt-4"
      on:click={LogIn}
      disabled={username.length == 0 || password.length == 0}
      >Zaloguj
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

<style>
  .prostokat {
    max-width: 600px;
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    margin: auto;
    text-align: center;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .napis {
    font-weight: 500;
    padding: 10px;
  }
  .pola {
    margin: auto;
    max-width: 400px;
  }
  .btn-success {
    width: 50%;
    border-radius: 5px;
  }
</style>
