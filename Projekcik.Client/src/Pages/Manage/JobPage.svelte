<script>
  import { onMount } from "svelte";
  import JobService from "../../Services/JobService.js";
  import { navigate } from "svelte-navigator";

  let jobs = [];

  onMount(async () => {
    Refresh();
  });

  function Refresh() {
    JobService.getJobsList().then((response) => {
      jobs = response;
    });
  }

  function JobAdd() {
    navigate("jobs/add", { replace: false });
  }

  function JobEdit(jobId) {
    navigate(`jobs/edit/${jobId}`, { replace: true });
  }

  function JobDelete(job) {
    console.log("delete", job);
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="title">
    <i class="fas fa-briefcase m-2" />Oferty Pracy
  </div>
  <p />
  <button class="btn btn-outline-primary dodaj" on:click={JobAdd}>
    <span class="fa fa-plus" aria-hidden="true" /> Dodaj ofertę
  </button>
  <p />
  <table class="table table-hover tabela">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Oferta</th>
        <th scope="col">Miejsce</th>
        <th scope="col">Firma</th>
        <th scope="col">Wypłata (zł)</th>
        <th scope="col">Edytuj</th>
        <th scope="col">Usuń</th>
      </tr>
    </thead>
    <tbody>
      {#each jobs as job, i}
        <tr>
          <th scope="row">{i + 1}</th>
          <td>{job.title}</td>
          <td>{job.location}</td>
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
