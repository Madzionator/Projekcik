<script>
  import { onMount } from "svelte";
  import JobService from "../../Services/JobService.js";
  import { navigate, Link } from "svelte-navigator";
  import { toast } from "@zerodevx/svelte-toast";

  let jobs = [];

  onMount(async () => {
    Refresh();
  });

  function Refresh() {
    JobService.getJobsStatsList().then((response) => {
      jobs = response;
    });
  }

  function JobAdd() {
    navigate("jobs/add", { replace: false });
  }

  function JobEdit(jobId) {
    navigate(`jobs/edit/${jobId}`, { replace: false });
  }

  function JobPreview(jobId) {
    navigate(`jobs/preview/${jobId}`, { replace: false });
  }

  function JobDelete(jobId) {
    JobService.deleteJob(jobId)
      .then((response) => {
        toast.push("usunięto ofertę pracy");
        Refresh();
      })
      .catch((response) => toast.push("nie udało się usunąć oferty"));
  }

  function LocationsToString(locations, max) {
    let locArray = locations?.map((loc) => loc.name);
    if (locArray.length == 0) return "--";
    if (locArray.length <= max) return locArray.join(", ");
    return `${locArray[0]}, ${locArray[1]}, +${locArray.length - 2}`;
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="title">
    <i class="fas fa-briefcase m-2" />Oferty Pracy
  </div>
  <p />
  <button class="btn btn-outline-primary" on:click={() => JobAdd()}>
    <span class="fa fa-plus" aria-hidden="true" /> Dodaj ofertę
  </button>
  <p />
  <table class="table table-hover tabela">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Oferta</th>
        <th scope="col">Lokalizacja</th>
        <th scope="col">Firma</th>
        <th scope="col">Wypłata (zł)</th>
        <th scope="col">Kandydaci</th>
        <th scope="col">Edytuj</th>
        <th scope="col">Usuń</th>
      </tr>
    </thead>
    <tbody>
      {#each jobs as job, i}
        <tr>
          <th scope="row">{i + 1}</th>
          <td>
            <div type="button" on:click={() => JobPreview(job.id)}>
              {job.title}
            </div>
          </td>
          <td>
            {LocationsToString(job.locations, 2)}
          </td>
          <td>{job.companyName}</td>
          <td>
            {#if job.minimumSalary}
              {job.minimumSalary}
            {/if}
            -
            {#if job.maximumSalary}
              {job.maximumSalary}
            {/if}
          </td>
          <td>
            {job.candidateCount}
          </td><td>
            <button class="btn" on:click={() => JobEdit(job.id)}>
              <span class="fa fa-edit" aria-hidden="true" />
            </button>
          </td>
          <td>
            <button class="btn" on:click={() => JobDelete(job.id)}>
              <span class="fa fa-times" aria-hidden="true" />
            </button>
          </td>
        </tr>
      {/each}
    </tbody>
  </table>
</div>

<style lang="scss">
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .title {
    font-size: large;
    text-align: center;
    border: 1px solid black;
    border-radius: 5px;
    background-color: rgba(76, 145, 94, 0.5);
  }
  .tabela {
    text-align: center;
  }
</style>
