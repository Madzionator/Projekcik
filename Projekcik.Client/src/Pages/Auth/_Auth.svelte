<script>
  import { Route, Router } from "svelte-navigator";
  import LoginPage from "./LoginPage.svelte";
  import LogoutPage from "./LogoutPage.svelte";
  import RegisterPage from "./RegisterPage.svelte";

  let routes = [
    { path: "register", component: RegisterPage },
    { path: "login", component: LoginPage },
    { path: "logout", component: LogoutPage },
  ];
</script>

<Router>
  {#each routes as route}
    <Route {...route} />
  {/each}
</Router>
