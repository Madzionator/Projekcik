<script>
  export let todo;
  let datetime = new Date(todo.termin);
  let start = new Date();
  let diff = (datetime - start) / (1000 * 60 * 60 * 24);
  let b_color;
  if (diff < 0) b_color = "lightgrey";
  else if (diff <= 1) b_color = "darkorange";
  else if (diff <= 7) b_color = "gold";
  else b_color = "white";
</script>

<div class="todo_element" style="background-color: {b_color}">
  <div class="todo_title"><p>{todo.title}</p></div>
  <div class="todo_date">
    <p>{datetime.toLocaleDateString()} o {datetime.toLocaleTimeString()}</p>
  </div>
</div>

<style>
  .todo_element {
    border: 2px solid black;
    height: 150px;
    width: 300px;
    border-radius: 20px;
    margin: 8px;
  }
  .todo_title {
    border: 1px solid black;
    background-color: skyblue;
    height: 50px;
    width: 255px;
    border-radius: 10px;
    margin: 8px;
    line-height: 50px;
    box-sizing: content-box;
    text-align: center;
    margin-bottom: 20px;
  }
  .todo_date {
    text-align: left;
    margin: 8px;
    line-height: 10px;
    box-sizing: content-box;
  }
</style>
