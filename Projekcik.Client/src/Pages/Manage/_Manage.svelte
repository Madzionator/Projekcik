<script>
  import { Router } from "svelte-navigator";
  import ProtectedRoute from "../../Components/ProtectedRoute.svelte";
  import JobPage from "./JobPage.svelte";
  import LocationPage from "./LocationPage.svelte";
  import ManagePage from "./ManagePage.svelte";

  let protectedRoutes = [
    { path: "", component: ManagePage },
    { path: "locations", component: LocationPage },
    { path: "jobs", component: JobPage },
  ];
</script>

<Router>
  {#each protectedRoutes as protectedRoute}
    <ProtectedRoute routeParams={protectedRoute} />
  {/each}
</Router>
