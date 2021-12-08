const { promises: fsp } = require("fs");

const { RunPart2 } = require("./src/part2");
const { RunPart1 } = require("./src/part1");

async function main() {
  const data = await fsp.readFile("./input.txt", "utf8");
  const lines = data.split(/\r?\n/);

  await RunPart1(lines);
  await RunPart2(lines);
}
main();
