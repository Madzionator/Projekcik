<script>
  import { navigate } from "svelte-navigator";
  import AuthService from "../../Services/AuthService";
  import { toast } from "@zerodevx/svelte-toast";
  let logo = "./images/logo.png";

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

<head>
  <style>
    body {
      background-color: #eee;
    }
  </style>
</head>

<body>
  <div class="container prostokat">
    <img src={logo} alt="logo" width="60%" />
    <div class="napis">
      <p>Panel administracyjny</p>
    </div>
    <div class="pola">
      <div class="form-group">
        <label for="exampleInputLogin1">Login</label>
        <input
          bind:value={username}
          class="form-control"
          id="exampleInputLogin1"
          placeholder="Twój login"
        />
        <p />
        <label for="exampleInputPassword1">Hasło</label>
        <input
          type="password"
          bind:value={password}
          class="form-control"
          id="exampleInputPassword1"
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
</body>

<style>
  .prostokat {
    padding: 50px;
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    margin: auto;
    width: 50%;
    text-align: center;
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
