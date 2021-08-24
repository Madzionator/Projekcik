<script>
  import RegisterPage from "./Pages/Auth/RegisterPage.svelte";
  import { Router, Link, Route } from "svelte-navigator";
  import Header from "./Components/Header.svelte";
  import ErrorPage from "./Pages/ErrorPage.svelte";
  import HomePage from "./Pages/HomePage.svelte";
  import LoginPage from "./Pages/Auth/LoginPage.svelte";
  import { SvelteToast } from "@zerodevx/svelte-toast";
  import LogoutPage from "./Pages/Auth/LogoutPage.svelte";
  import ManagePage from "./Pages/ManagePage.svelte";
  import AuthService from "./Services/AuthService";
  import ProtectedRoute from "./Components/ProtectedRoute.svelte";

  const routes = [
    { path: "/", component: HomePage },
    //auth
    { path: "register", component: RegisterPage },
    { path: "login", component: LoginPage },
    { path: "logout", component: LogoutPage },
  ];

  const protectedRoutes = [{ path: "manage", component: ManagePage }];
</script>

<Router>
  <Header />
  <div>
    {#each routes as route}
      <Route {...route} />
    {/each}

    {#each protectedRoutes as protectedRoute}
      <ProtectedRoute routeParams={protectedRoute} />
    {/each}
    <Route component={ErrorPage} />
  </div>
</Router>
<SvelteToast />
