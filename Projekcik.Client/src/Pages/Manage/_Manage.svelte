<script>
  import { Router } from "svelte-navigator";
  import ProtectedRoute from "../../Components/ProtectedRoute.svelte";
  import CandidatePage from "./CandidatePage.svelte";
  import JobAddPage from "./JobAddPage.svelte";
  import JobEditPage from "./JobEditPage.svelte";
  import JobPage from "./JobPage.svelte";
  import JobPreviewPage from "./JobPreviewPage.svelte";
  import LocationPage from "./LocationPage.svelte";
  import ManagePage from "./ManagePage.svelte";

  let protectedRoutes = [
    { path: "", component: ManagePage },
    { path: "locations", component: LocationPage },
    { path: "jobs", component: JobPage },
    { path: "jobs/add", component: JobAddPage },
    { path: "jobs/edit/:id", component: JobEditPage },
    { path: "jobs/preview/:id", component: JobPreviewPage },
    { path: "candidates", component: CandidatePage },
  ];
</script>

<Router>
  {#each protectedRoutes as protectedRoute}
    <ProtectedRoute routeParams={protectedRoute} />
  {/each}
</Router>
