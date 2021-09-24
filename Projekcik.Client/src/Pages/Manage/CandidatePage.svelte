<script>
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import CandidateService from "../../Services/CandidateService";

  let candidates = [];
  let visibleComment = "";

  onMount(async () => {
    CandidateService.getCandidatesList().then((response) => {
      candidates = response;
    });
  });

  function CvDownload(candidate) {
    CandidateService.downloadFile(candidate.id)
      .then((response) => {
        const url = window.URL.createObjectURL(response.data);
        const link = document.createElement("a");
        link.href = url;
        link.setAttribute(
          "download",
          `${candidate.firstName}.${candidate.lastName}.${candidate.id}.pdf`
        );
        link.click();
      })
      .catch((response) =>
        toast.push("Wystąpił błąd, zawartość mogła zostać usunięta 😿")
      );
  }
</script>

<div class="container prostokat p-3 p-lg-5 mx-auto my-5">
  <div class="title mb-3">
    <i class="fas fa-user m-2" />Kandydaci
  </div>

  <table class="table table-hover tabela">
    <thead>
      <tr>
        <th scope="col">#</th>
        <th scope="col">Imię</th>
        <th scope="col">Nazwisko</th>
        <th scope="col">Telefon Kontakotowy</th>
        <th scope="col">Adres email</th>
        <th scope="col">Komentarz</th>
        <th scope="col">CV</th>
      </tr>
    </thead>
    <tbody>
      {#each candidates as candidate, i}
        <tr>
          <th scope="row">{i + 1}</th>
          <td>{candidate.firstName}</td>
          <td>
            {candidate.lastName}
          </td>
          <td>{candidate.phoneNumber}</td>
          <td> {candidate.emailAddress}</td>
          <td>
            <button
              class="btn"
              data-bs-toggle="modal"
              data-bs-target="#commentModal"
              on:click={() => {
                candidate.comment
                  ? (visibleComment = candidate.comment)
                  : (visibleComment = "");
              }}
            >
              <span class="far fa-comment-alt m-2" aria-hidden="true" />
            </button>
          </td>
          <td>
            <button class="btn" on:click={() => CvDownload(candidate)}>
              <span class="fa fa-download" aria-hidden="true" />
            </button>
          </td>
        </tr>
      {/each}
    </tbody>
  </table>

  <!-- Modal -->
  <div
    class="modal fade"
    id="commentModal"
    tabindex="-1"
    aria-labelledby="commentModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="commentModalLabel">Kilka słów o sobie</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          />
        </div>
        <div class="modal-body">{visibleComment}</div>
        <div class="modal-footer">
          <button
            type="button"
            class="btn btn-secondary"
            data-bs-dismiss="modal">Close</button
          >
        </div>
      </div>
    </div>
  </div>
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
