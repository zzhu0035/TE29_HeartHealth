# plumber.R

#* Echo back the input
#* @param msg The message to echo
#* @get /echo
function(msg="") {
  list(msg = paste0("The message is: '", msg, "'"))
}

# recommendation.R
#' Echo the parameter that was sent in
#' @param msg The message to echo back.
#' @get /recommend
function(weight_sel, sport_sel, diff_sel){
  w_temp = as.numeric(weight_sel)
  sport_type = sport_sel
  diff_sel_inp = diff_sel
  if (sport_type == "Running"){
    exe_data = exer_data[c(1:5),]
  } else if (sport_type == "Walking"){
    exe_data = exer_data[c(6:10),]
  } else if (sport_type == "Bicycle"){
    exe_data = exer_data[c(11:19),]
  } else if (sport_type == "Jump"){
    exe_data = exer_data[c(20:22),]
  } else if (sport_type == "Aquatics"){
    exe_data = exer_data[c(23:27),]
  } else if (sport_type == "Seaside"){
    exe_data = exer_data[c(28:29),]
  } else if (sport_type == "Ball"){
    exe_data = exer_data[c(30:36),]
  } else if (sport_type == "Taichi"){
    exe_data = exer_data[c(37),]
  } else if (sport_type == "Aerobics"){
    exe_data = exer_data[c(38:42),]
  } else if (sport_type == "Family"){
    exe_data = exer_data[c(43),]
  } else {
    exe_data = exer_data
  }
  w_final = as.integer(w_temp*2.20462)
  if (w_final < 155) {
    w_filtered = exe_data %>% select(c(1,2))
    if (diff_sel_inp == "1"){        # Mild/Slow-paced
      cal_category_min = 110
      cal_category_max = 330
    } else if (diff_sel_inp == "2"){ # Moderate
      cal_category_min = 331
      cal_category_max = 520
    } else if (diff_sel_inp == "3"){ # High/Fast-paced
      cal_category_min = 521
      cal_category_max = 830
    }
  } else if (w_final < 180) {
    w_filtered = exe_data %>% select(c(1,3))
    if (diff_sel_inp == "1"){        # Mild/Slow-paced
      cal_category_min = 110
      cal_category_max = 400
    } else if (diff_sel_inp == "2"){ # Moderate
      cal_category_min = 401
      cal_category_max = 600
    } else if (diff_sel_inp == "3"){ # High/Fast-paced
      cal_category_min = 601
      cal_category_max = 1000
    }
  } else if (w_final < 205) {
    w_filtered = exe_data %>% select(c(1,4))
    if (diff_sel_inp == "1"){        # Mild/Slow-paced
      cal_category_min = 110
      cal_category_max = 460
    } else if (diff_sel_inp == "2"){ # Moderate
      cal_category_min = 461
      cal_category_max = 700
    } else if (diff_sel_inp == "3"){ # High/Fast-paced
      cal_category_min = 701
      cal_category_max = 1200
    }
  } else {
    w_filtered = exe_data %>% select(c(1,5))
    if (diff_sel_inp == "1"){        # Mild/Slow-paced
      cal_category_min = 110
      cal_category_max = 520
    } else if (diff_sel_inp == "2"){ # Moderate
      cal_category_min = 521
      cal_category_max = 800
    } else if (diff_sel_inp == "3"){ # High/Fast-paced
      cal_category_min = 801
      cal_category_max = 1400
    }
  }
  names(w_filtered)[1] = "exercises"
  names(w_filtered)[2] = "calories"
  w_filtered$exercises = as.character(w_filtered$exercises)
  if (diff_sel_inp == "0"){ # all
    final_frame = w_filtered
  } else {
    cal_category_min_final = as.integer(cal_category_min)
    cal_category_max_final = as.integer(cal_category_max)
    final_frame_temp = w_filtered %>% filter(w_filtered$calories >= cal_category_min_final)
    final_frame = final_frame_temp %>% filter(final_frame_temp$calories <= cal_category_max_final)
  }
  final_frame
}