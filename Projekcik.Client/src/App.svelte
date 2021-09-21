<script>
  import _Auth from "./Pages/Auth/_Auth.svelte";
  import _Manage from "./Pages/Manage/_Manage.svelte";
  import { Router, Link, Route } from "svelte-navigator";
  import { SvelteToast } from "@zerodevx/svelte-toast";
  import Header from "./Components/Header.svelte";
  import ErrorPage from "./Pages/ErrorPage.svelte";
  import ProtectedRoute from "./Components/ProtectedRoute.svelte";
  import AboutPage from "./Pages/AboutPage.svelte";
  import HomePage from "./Pages/HomePage.svelte";
  import Footer from "./Components/Footer.svelte";
  import JobInfoPage from "./Pages/JobInfoPage.svelte";
  import JobApplyPage from "./Pages/JobApplyPage.svelte";

  const routes = [
    { path: "/", component: HomePage },
    { path: "about", component: AboutPage },
    { path: "auth/*", component: _Auth },
    { path: "job/:id", component: JobInfoPage },
    { path: "job/apply/:id", component: JobApplyPage },
  ];

  const protectedRoutes = [{ path: "manage/*", component: _Manage }];
</script>

<Router>
  <div class="main">
    <div class="header">
      <Header />
    </div>

    <div class="content">
      {#each routes as route}
        <Route {...route} />
      {/each}
      {#each protectedRoutes as protectedRoute}
        <ProtectedRoute routeParams={protectedRoute} />
      {/each}
      <Route component={ErrorPage} />
    </div>
    <div class="footer">
      <Footer />
    </div>
  </div>
</Router>
<SvelteToast
  options={{
    theme: {
      "--toastBackground": "#48BB78",
      "--toastProgressBackground": "#2F855A",
    },
  }}
/>

<style>
  .main {
    min-height: 100vh;
    display: flex;
    flex-direction: column;
  }

  .header {
    flex: 0;
  }

  .content {
    flex: 1;
    display: flex;
    flex-direction: column;
  }
</style>
