use std::fs::File;
use std::io::{self, BufRead};
use std::path::Path;

fn main() {
  let lines = &read_line_numbers("./input.txt");
  challenge1(lines);
  challenge2(lines);
}

fn challenge1(lines: &Vec<i32>) {
  let answer = lines.windows(2).filter(|w| w[1] > w[0]).count();

  println!("Challenge 1 answer is {}", answer)
}

fn challenge2(lines: &Vec<i32>) {
  let sliding_windows: Vec<i32> = lines.windows(3).map(|w| w.iter().sum()).collect();
  let answer = sliding_windows.windows(2).filter(|w| w[1] > w[0]).count();

  println!("Challenge 2 answer is {}", answer)
}

fn read_line_numbers<P>(filename: P) -> Vec<i32>
where
  P: AsRef<Path>,
{
  io::BufReader::new(File::open(filename).expect("file not found"))
    .lines()
    .filter_map(|l| l.ok())
    .filter_map(|l| l.parse::<i32>().ok())
    .collect()
}
