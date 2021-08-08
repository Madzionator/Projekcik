<script>
  import TodoItem from "./../../Components/TodoItem.svelte";
  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import TimePicker from "svelte-time-picker";
  import TodoService from "../../Services/TodoService";

  let title = "";
  let time = new Date();
  let date;

  let dateString = "";
  let now = new Date();

  onMount(() => {
    dateString = new Date(
      now.getFullYear(),
      now.getMonth(),
      now.getDate()
    ).toLocaleDateString();
  });

  let changeTime = (event) => {
    time = event.detail;
  };

  function AddNewTodo() {
    //this is so ugly
    let d = dateString.split("-");
    date = new Date(d[0], d[1], d[2], time.getHours(), time.getMinutes());

    TodoService.createTodo(title, date)
      .catch((x) => {
        const response = x.response;
        console.log(response);
      })
      .then(() => {
        navigate("/todo", { replace: true });
      });
  }
</script>

<div class="container">
  <p />
  <div class="input">
    <p>Podaj tytuł, date i godzinę zadania:</p>
    <input bind:value={title} type="text" />

    <label>
      <input type="date" bind:value={dateString} />
    </label>

    <TimePicker date={now} on:change={changeTime} />
  </div>

  <TodoItem todo={{ title: title, termin: date }} />

  <button class="zapisz" on:click={AddNewTodo} disabled={title.length == 0}>
    zapisz zadanie
  </button>
</div>

<style>
  .zapisz {
    border: 1px solid rgb(65, 65, 65);
    height: 50px;
    width: 150px;
    border-radius: 20px;
    margin: 8px;
    font-weight: bold;
  }
</style>
