<script>
  import marked from "marked";
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";
  import { navigate, Link } from "svelte-navigator";
  import JobService from "../Services/JobService";

  export let id;
  export let canApply = true;
  let job;
  let keywords = ["C#", ".NET", "C++", "js"]; // temporary

  onMount(async () => {
    JobService.getJob(id)
      .then((response) => {
        job = response;
      })
      .catch((response) => {
        toast.push("oferta nie istnieje");
        navigate("/", { replace: true });
      });
  });
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  {#if job}
    <h7 class="clue">Oferta pracy</h7>
    <h4>{job.title} <span class="company">{job.companyName}</span></h4>

    <div class="row">
      <div class="col-6">
        <p class="clue">Lokalizacja</p>
      </div>
      <div class="col-6">
        <p class="clue">Wynagrodzenie</p>
      </div>
    </div>
    <div class="row">
      <div class="col-6">
        {job.locations?.map((loc) => loc.name).join(", ") || "--"}
      </div>
      <div class="col-6">
        {job.minimumSalary ?? ""} - {job.maximumSalary ?? ""} PLN
      </div>
    </div>
    <div class="mt-2">
      {#each keywords as keyword}
        <span class="badge bg-secondary keyword">{keyword}</span>
      {/each}
    </div>
    <p class="clue">Opis</p>
    <div class="preview">{@html marked(job.description)}</div>

    {#if canApply}
      <Link to="/job/apply/{job.id}">
        <button class="btn btn-success apply"> Aplikuj </button>
      </Link>
    {/if}
  {:else}
    <div class="d-flex justify-content-center">
      <div class="spinner-border" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    </div>
  {/if}
</div>

<style lang="scss">
  .prostokat {
    background-color: white;
    border: 1px solid black;
    border-radius: 5px;
    border-bottom-width: 2px;
    box-shadow: 3px 3px 10px rgba(0, 0, 0, 0.2);
  }
  .clue {
    color: grey;
    margin: 0.75rem 0 0 0;
  }
  .company {
    color: grey;
    font-size: large;
    font-weight: 400;
  }
  .keyword {
    margin: 3px;
    &:first-child {
      margin-left: 0;
    }
  }
  .apply {
    @import "src/global.scss";
    width: 100px;
    background-color: rgba($green1, 0.8);
    color: black;
    &:hover,
    &:focus {
      background-color: $green2;
      color: black;
    }
  }
</style>
