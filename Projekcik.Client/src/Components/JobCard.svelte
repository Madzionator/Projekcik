<script>
  export let title;
  export let minimumSalary;
  export let maximumSalary;
  export let companyName;
  // export location;
  // export let keywords;
  let keywords = ["C#", ".NET", "C++", "js"];
</script>

<div class="card job_element">
  <div class="card-body">
    <h5 class="card-title job_title">
      <i class="fas fa-briefcase m-2" />{title}
    </h5>
    <div class="data">
      <div class="row">
        <div class="col">
          <i class="fas fa-building" />
          {companyName}
        </div>
        <div class="col">
          <i class="fas fa-money-bill-alt" />
          {minimumSalary || ""} - {maximumSalary || ""} PLN
        </div>
      </div>
      <div class="row">
        <div class="col">
          <i class="fas fa-map-marker-alt" /> jakaś lokalizacja
        </div>
        <div class="col">
          {#each keywords as keyword}
            <span class="badge bg-secondary keyword">{keyword}</span>
          {/each}
        </div>
      </div>
    </div>
  </div>
</div>

<style lang="scss">
  .job_element {
    margin-top: 5px;
    border-radius: 5px;
    border-bottom: 2px solid rgba(royalblue, 0.6);
    border-right: 1px solid rgba(royalblue, 0.6);
  }
  .data {
    margin: 4px 8px 4px 8px;
    line-height: 30px;
  }
  .keyword {
    margin-right: 3px;
  }
</style>
