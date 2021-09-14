<script>
  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";

  import Banner from "../Components/Banner.svelte";
  import JobCard from "../Components/JobCard.svelte";
  import JobService from "../Services/JobService";

  let jobs = [];

  onMount(async () => {
    JobService.getJobsList().then((response) => {
      jobs = response;
    });
  });

  function GoToJob(jobId) {
    navigate(`job/${jobId}`, { replace: false });
  }
</script>

<Banner />
<h3 class="text-center">Najnowsze oferty pracy</h3>
<div class="container prostokaciki">
  <div class="row">
    {#each jobs as job}
      <div
        class="col-12 col-md-12 col-lg-6"
        type="button"
        on:click={GoToJob(job.id)}
      >
        <JobCard {...job} />
      </div>
    {/each}
  </div>
</div>

<div class="p-5" />

<style lang="scss">
</style>
